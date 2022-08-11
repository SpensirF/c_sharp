// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
namespace ChefsAndDishes.Controllers;
    
public class DishController : Controller
{
    private ChefsnDishesContext DATABASE;
    
    // here we can "inject" our context service into the constructor
    public DishController(ChefsnDishesContext context)
    {
        DATABASE = context;
    }
    
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllMonsters = DATABASE.Dishes.ToList();

        return View();
    }
}
