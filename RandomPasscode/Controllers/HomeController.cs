using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CreatePassword;
using Microsoft.AspNetCore.Http;


namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        HttpContext.Session.SetInt32( "passcode", 1 );
        Password newPassword = new Password();

        return View("Index", newPassword);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    
    [ HttpGet("/generate") ]
    public IActionResult GeneratePasscode()
    {
        int? passcode = HttpContext.Session.GetInt32( "passcode" );
        passcode++;
        if( passcode.HasValue )
        {
            HttpContext.Session.SetInt32( "passcode", passcode.Value );
        }
        Password newPassword = new Password();

        return View( "Index", newPassword );

    }

}
