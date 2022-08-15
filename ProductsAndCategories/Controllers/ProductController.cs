// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;
    
public class ProductController : Controller
{
    private ProductsnCategoriesContext DATABASE;
    
    // here we can "inject" our context service into the constructor
    public ProductController(ProductsnCategoriesContext context)
    {
        DATABASE = context;
    }


    [HttpGet("/")]
    [HttpGet("/Products")]
    public IActionResult All()
    {
        List<Product> Products = DATABASE.Products.ToList();
        ViewBag.AllProducts = Products;

        return View("Products");
    }

    [HttpGet("products/{prodId}")]
        public IActionResult OneProduct(int prodId)
        {
            Product? OneProduct = DATABASE.Products.FirstOrDefault(p => p.ProductId == prodId);
            ViewBag.ThisProduct = OneProduct;

            var prodWithCats = DATABASE.Products
                .Include(p => p.item)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(p => p.ProductId == prodId);
            
            ViewBag.ProductWithCategories = prodWithCats;

            List<Category> EveryCategory = DATABASE.Categories.ToList();
            List<Category> SomeCategories = new List<Category>();

            foreach (var c in prodWithCats.)
            {
                SomeCategories.Add(c.Category);
            }
            List<Category> NotYetAssoc = EveryCategory.Except(SomeCategories).ToList();
            ViewBag.NotYetAssoc = NotYetAssoc;
            return View("SpecificProduct");
        }


    //---->                   POST                                   





    [HttpPost("/product/new")]
    public IActionResult New(Product NewProduct)
    {
        ViewBag.Categories = DATABASE.Categories.ToList();
        DATABASE.Add(NewProduct);
        DATABASE.SaveChanges();
        return RedirectToAction("Products");
    }






}