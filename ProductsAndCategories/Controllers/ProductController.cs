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
    public IActionResult AllProducts()
    {
        List<Product> Products = DATABASE.Products.ToList();
        ViewBag.AllProducts = Products;

        return View("Products");
    }

    [HttpGet("/product/{prodId}")]
        public IActionResult OneProduct(int prodId)
        {
            ViewBag.Product = DATABASE.Products
            .Include(p => p.item)
            .ThenInclude(a => a.Category)
            .FirstOrDefault(p => p.ProductId == prodId);

            ViewBag.SingleProduct = DATABASE.Products.FirstOrDefault(p => p.ProductId == prodId);
            
            ViewBag.CatNoAssoc = DATABASE.Categories
                .Include(c => c.group)
                .Where(p => !p.group.Any(p => p.ProductId == prodId));

            if(ViewBag.Products != null){
                return View("OneProduct");
            }

        return View("OneProduct");
        }


    //---->                   POST                                   





    [HttpPost("/product/new")]
    public IActionResult NewProduct(Product NewProduct)
    {
        ViewBag.Categories = DATABASE.Categories.ToList();
        DATABASE.Add(NewProduct);
        DATABASE.SaveChanges();
        return RedirectToAction("AllProducts");
    }

    [HttpPost("/AddCategory/{prodID}")]
        public IActionResult AddCategory(Association newAssociation, int prodID)
        {
            newAssociation.ProductId = prodID;
            DATABASE.Associations.Add(newAssociation);
            DATABASE.SaveChanges();
            // return Redirect("/products/"+newAssociation.ProductId);
            return RedirectToAction("AllProducts");
        }






}