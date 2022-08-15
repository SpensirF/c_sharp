// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;
    
public class CategoryController : Controller
{
    private ProductsnCategoriesContext DATABASE;
    
    // here we can "inject" our context service into the constructor
    public CategoryController(ProductsnCategoriesContext context)
    {
        DATABASE = context;
    }



    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        List<Category> Categories = DATABASE.Categories.ToList();
        ViewBag.AllCategories = Categories;

        return View("Categories");
    }


}