// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers;
    
public class DishController : Controller
{
    private ChefsnDishesContext DATABASE;
    
    // here we can "inject" our context service into the constructor
    public DishController(ChefsnDishesContext context)
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

    
    [HttpGet("/dishes/all")]
    public IActionResult All()
    {
        List<Dish> AllDishes = DATABASE.Dishes.ToList();

        return View("All", AllDishes);
    }



    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        ViewBag.AllChefs = DATABASE.Chefs.ToList();
        return View("NewDish");
    }
    [HttpGet("")]
    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        List<Dish> EveryDish = DATABASE.Dishes.Include(d => d.Author).ToList();
        ViewBag.AllDishes = EveryDish;
        return View("All");
    }




//---->                   POST                                   


[HttpPost("/dish/create")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid == false)
        {
            return New();
        }
        DATABASE.Dishes.Add(newDish);
        DATABASE.SaveChanges();

        return RedirectToAction("All");
    }








}