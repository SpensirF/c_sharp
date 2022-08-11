using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers; 




public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("userform")]
    
    public IActionResult Userform(string name, string location, string language, string comments)
    {
        
            ViewBag.Name = name;
            ViewBag.location = location; 
            ViewBag.language = language; 
            ViewBag.comments = comments;
            return View("Results");
    }

}

