using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost("/Create")]
    public IActionResult Create(User user)
    {
        if(ModelState.IsValid)
        {
            return View("Results", user);
        }
        else
        {
            return Index(); 
        }
            
    }

}
