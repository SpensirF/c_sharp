using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetUpCenter.Models;

namespace MeetUpCenter.Controllers;

public class MeetUpController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("U-ID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    private MeetUpCenterContext DATABASE;

    public MeetUpController(MeetUpCenterContext context)
    {
        DATABASE = context;
    }

    [HttpGet("/meetup/new")]
    public IActionResult NewMeetup()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        return View("NewMeetup");
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        List<MeetUp> allMeetups = DATABASE.MeetUps.OrderBy(t => t.Date)
        .Include(w => w.MeetupCreator)
        .Include(w => w.Occasion)
        .ToList();

        return View("Dashboard", allMeetups);
    }

    [HttpGet("/meetup/{meetId}")]
    public IActionResult OneMeetup(int meetId)
    {
        if(!loggedIn)
    {
        return RedirectToAction("Index", "User");
    }
        MeetUp? oneMeetup = DATABASE.MeetUps
        .Include(c => c.MeetupCreator)
        .Include(w => w.Occasion)
        .ThenInclude(g => g.Participant)
        .FirstOrDefault(wedd => wedd.MeetupId == meetId);

        if(oneMeetup == null )
        {
            return RedirectToAction("Dashboard");
        }

        return View("OneMeetup", oneMeetup);


    }

//---->                   POST                                   

    [HttpPost("/meetup/create")]
    public IActionResult CreateMeeting(MeetUp newMeetup)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        if(ModelState.IsValid == false)
        {
            return NewMeetup();
        }
        //updated meetup to have current user 
        newMeetup.UserId = (int)uid; 
        DATABASE.MeetUps.Add(newMeetup);
        DATABASE.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/meetup/{meetId}/rsvp")]
    public IActionResult RSVP(int meetId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        MeetupParticipant? existingGuest = DATABASE.MeetupParticipants.FirstOrDefault(wg => wg.UserId == (int)uid && wg.MeetUpId == meetId);

        if(existingGuest != null)
        {
            DATABASE.Remove(existingGuest);
        }
        else
        {
            MeetupParticipant newGuest = new MeetupParticipant(){
                UserId = (int)uid,
                MeetUpId = meetId
        };
            
        DATABASE.MeetupParticipants.Add(newGuest);
        }
        DATABASE.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/meetup/{meetId}/delete")]
    public IActionResult DeleteMeetup(int meetId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        if(ModelState.IsValid == false)
        {
            return View("Index","User");
        }

        MeetUp? meetDelete = DATABASE.MeetUps.FirstOrDefault(w => w.MeetupId == meetId);

        if(meetDelete == null || meetDelete.UserId != (int)uid)
        {
            return RedirectToAction("Dashboard");
        }

        DATABASE.Remove(meetDelete);
        DATABASE.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    






}