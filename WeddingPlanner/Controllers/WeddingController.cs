using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
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
    private WeddingPlannerContext DATABASE;

    public WeddingController(WeddingPlannerContext context)
    {
        DATABASE = context;
    }

    [HttpGet("/wedding/new")]
    public IActionResult NewWedding()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        return View("NewWedding");
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        List<Wedding> allWeddings = DATABASE.Weddings.Include(w => w.WeddGuest).ToList();

        return View("Dashboard", allWeddings);
    }

    [HttpGet("/wedding/{weddId}")]
    public IActionResult OneWedding(int weddId)
    {
        if(!loggedIn)
    {
        return RedirectToAction("Index", "User");
    }
        Wedding? oneWedding = DATABASE.Weddings
        .Include(w => w.WeddGuest)
        .ThenInclude(g => g.Guest)
        .FirstOrDefault(wedd => wedd.WeddingId == weddId);

        if(oneWedding == null )
        {
            return RedirectToAction("Dashboard");
        }

        return View("OneWedding", oneWedding);

    }




//---->                   POST                                   

    [HttpPost("/wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        if(ModelState.IsValid == false)
        {
            return NewWedding();
        }
        //updated wedding to have current user 
        newWedding.UserId = (int)uid; 
        DATABASE.Weddings.Add(newWedding);
        DATABASE.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/wedding/{weddId}/rsvp")]
    public IActionResult RSVP(int weddId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        WeddingGuest? existingGuest = DATABASE.WeddingGuests.FirstOrDefault(wg => wg.UserId == (int)uid && wg.WeddingId == weddId);

        if(existingGuest != null)
        {
            DATABASE.Remove(existingGuest);
        }
        else
        {
            WeddingGuest newGuest = new WeddingGuest(){
                UserId = (int)uid,
                WeddingId = weddId
        };
            
        DATABASE.WeddingGuests.Add(newGuest);
        }

        DATABASE.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/wedding/{weddId}/delete")]
    public IActionResult DeleteWedding(int weddId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "User");
        }

        if(ModelState.IsValid == false)
        {
            return View("Index","User");
        }

        Wedding? weddDelete = DATABASE.Weddings.FirstOrDefault(w => w.WeddingId == weddId);

        if(weddDelete == null || weddDelete.UserId != (int)uid)
        {
            return RedirectToAction("Dashboard");
        }

        DATABASE.Remove(weddDelete);
        DATABASE.SaveChanges();
        return RedirectToAction("Dashboard");
    }



}