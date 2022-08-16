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
    public IActionResult AllCategories()
    {
        List<Category> Categories = DATABASE.Categories.ToList();
        ViewBag.AllCategories = Categories;

        return View("Categories");
    }
    [HttpGet("/category/{categoryId}")]
        public IActionResult OneCategory(int categoryId)
        {
            ViewBag.Category = DATABASE.Categories
            .Include(p => p.group)
            .ThenInclude(a => a.Product)
            .FirstOrDefault(p => p.CategoryId == categoryId);

            ViewBag.SingleCategory = DATABASE.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
            
            ViewBag.ProdNoAssoc = DATABASE.Products
                .Include(c => c.item)
                .Where(p => !p.item.Any(p => p.CategoryId == categoryId));

            if(ViewBag.Categories != null){
                return View("OneCategory");
            }

        return View("OneCategory");
        }




//---->                   POST                                   

[HttpPost("/category/new")]
    public IActionResult NewCategory(Category NewCategory)
    {
        ViewBag.Categories = DATABASE.Categories.ToList();
        DATABASE.Add(NewCategory);
        DATABASE.SaveChanges();
        return RedirectToAction("AllCategories");
    }

    [HttpPost("/AddProduct/{categoryID}")]
        public IActionResult AddProduct(Association newproductAssociation, int categoryID)
        {
            newproductAssociation.CategoryId = categoryID;
            DATABASE.Associations.Add(newproductAssociation);
            DATABASE.SaveChanges();
            // return Redirect("/products/"+newAssociation.ProductId);
            return OneCategory(categoryID);
        }


}