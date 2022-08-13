// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers;
    
public class ChefController : Controller
{
    private ChefsnDishesContext DATABASE;
    
    // here we can "inject" our context service into the constructor
    public ChefController(ChefsnDishesContext context)
    {
        DATABASE = context;
    }
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("C-ID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    [HttpGet("/chefs/all")]
    public IActionResult All()
    {
        List<Chef> AllChefs = DATABASE.Chefs.ToList();

        return View("Chefs", AllChefs);
    }

    [HttpGet("/chef/new")]
    public IActionResult New()
    {
        return View("NewChef");
    }

    [HttpGet("/chefs")]
        public IActionResult Chefs()
        {
            List<Chef> TheChefs = DATABASE.Chefs.Include(c => c.CreatedDishes).ToList();
            ViewBag.AllChefs = TheChefs;
            return View("Chefs");
        }






    //---->                   POST                                   

    [HttpPost("/chef/create")]
    public IActionResult Create(Chef newChef)
    {
        if(ModelState.IsValid == false)
        {
            return New();
        }
        DATABASE.Chefs.Add(newChef);
        DATABASE.SaveChanges();

        return RedirectToAction("Chefs");
    }




}