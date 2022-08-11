using Microsoft.AspNetCore.Mvc;
namespace PortfolioOne.Controllers;





public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("projects")]
    public IActionResult Projects()
    {
    return View("Projects");
    }   

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }

}