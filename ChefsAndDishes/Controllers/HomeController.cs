using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}