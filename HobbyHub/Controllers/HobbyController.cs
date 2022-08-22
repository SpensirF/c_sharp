using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HobbyHub.Models;

namespace HobbyHub.Controllers;

public class HobbyController : Controller
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
    private HobbyHubContext DATABASE;

    public HobbyController(HobbyHubContext context)
    {
        DATABASE = context;
    }


    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        List<Hobby> allHobbies = DATABASE.Hobbies
        .Include(w => w.Enthusiast)
        .ToList();

        return View("Dashboard", allHobbies);

    }

    [HttpGet("/hobby/new")]
    public IActionResult NewHobby()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        return View("NewHobby");
    }


    [HttpGet("/hobby/{hobbId}")]
    public IActionResult OneHobby(int hobbId)
    {
        if(!loggedIn)
    {
        return RedirectToAction("Index", "User");
    }
        Hobby? oneHobby = DATABASE.Hobbies
        
        .Include(w => w.Enthusiast)
        .ThenInclude(g => g.Obsession)
        .FirstOrDefault(hobb => hobb.HobbyId == hobbId);

        if(oneHobby == null )
        {
            return RedirectToAction("Dashboard");
        }
        return View("OneHobby", oneHobby);


    }


//---->                   POST                                   

    [HttpPost("/hobby/create")]
    public IActionResult CreateHobby(Hobby newHobby)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        if(ModelState.IsValid == false)
        {
            return NewHobby();
        }
        //updated meetup to have current user 
        newHobby.UserId = (int)uid; 
        DATABASE.Hobbies.Add(newHobby);
        DATABASE.SaveChanges();

        return RedirectToAction("Dashboard");
    }
    [HttpPost("/hobby/{hobbId}/rsvp")]
    public IActionResult RSVP(int hobbId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        HobbyEnthusiast? existingGuest = DATABASE.HobbyEnthusiasts.FirstOrDefault(wg => wg.UserId == (int)uid && wg.HobbyId == hobbId);

        if(existingGuest != null)
        {
            DATABASE.Remove(existingGuest);
        }
        else
        {
            HobbyEnthusiast newGuest = new HobbyEnthusiast(){
                UserId = (int)uid,
                HobbyId = hobbId
        };
            
        DATABASE.HobbyEnthusiasts.Add(newGuest);
        }
        DATABASE.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/hobby/{hobbId}/delete")]
    public IActionResult DeleteHobby(int hobbId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        if(ModelState.IsValid == false)
        {
            return View("Index","User");
        }

        Hobby? hobbDelete = DATABASE.Hobbies.FirstOrDefault(w => w.HobbyId == hobbId);

        if(hobbDelete == null || hobbDelete.UserId != (int)uid)
        {
            return RedirectToAction("Dashboard");
        }

        DATABASE.Remove(hobbDelete);
        DATABASE.SaveChanges();
        return RedirectToAction("Dashboard");
    }




}