// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;
namespace Crudelicious.Controllers;
    
public class DishController : Controller
{
    private DATABASE _context;

    // here we can "inject" our context service into the constructor
    public DishController(DATABASE context)
    {
        _context = context;
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
        return View("New");
    }

    [HttpGet("/Dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        // since firstordefault can return a single post, or null. our variable needs to be a nullable datatype
        Dish? dish = _context.Dishes.FirstOrDefault(post => post.DishId == dishId);
        
        // to get rid of "object might be null" warnings, write a conditional that checks for it & returns if it's null
        if (dish == null)
        {
            return RedirectToAction("All");
        }
        
        return View("ViewDish", dish);
    }
    [HttpGet("/dishes/{dishToBeEdited}/edit")]
    public IActionResult EditDish(int dishToBeEdited)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(post => post.DishId == dishToBeEdited);

        if (dish == null)
        {
            return RedirectToAction("All");
        }

        return View("Edit", dish);
    }




//---->                   POST                                   


    [HttpPost("/dish/create")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid == false)
        {
            return New();
        }
        _context.Dishes.Add(newDish);
        _context.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpPost("/dish/{deletedDishId}/delete")]
    public IActionResult Delete(int deletedDishId)
    {
        Dish? dishToBeDeleted = _context.Dishes.FirstOrDefault(dish => dish.DishId == deletedDishId);

        if (dishToBeDeleted != null)
        {
            _context.Dishes.Remove(dishToBeDeleted);
            _context.SaveChanges();
        }

        return RedirectToAction("All");
    }

    [HttpPost("/dishes/{updatedDishId}/update")]
    public IActionResult UpdateDish(int updatedDishId, Dish updatedDish)
    {
        if (ModelState.IsValid == false)
        {
            // can remove all of the code below as long as we don't default our View() function in EditPost

            // Post? originalPost = _context.Posts.FirstOrDefault(post => post.PostId == updatedPost.PostId);
            // if (originalPost == null)
            // {
            //     RedirectToAction("All");
            // }
            // return View("Edit", originalPost);

            return EditDish(updatedDishId);
        }

        Dish? crud_db = _context.Dishes.FirstOrDefault(dish => dish.DishId == updatedDishId);

        if (crud_db == null)
        {
            return RedirectToAction("All");
        }

        crud_db.Name = updatedDish.Name;
        crud_db.Chef = updatedDish.Chef;
        crud_db.Tastiness = updatedDish.Tastiness;
        crud_db.Calories = updatedDish.Calories;
        crud_db.Description = updatedDish.Description;
        crud_db.UpdatedAt = DateTime.Now;

        _context.Dishes.Update(crud_db);
        _context.SaveChanges();

        return RedirectToAction("ViewDish", new { dishId = crud_db.DishId });
    }




}
