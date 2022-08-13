// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;
using Microsoft.AspNetCore.Identity;

namespace Crudelicious.Controllers;
    
public class UserController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("U-ID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    // db is just a variable name, can be called anything (e.g. DATABASE, db, _db, etc)
    private DATABASE db;

    // here we can "inject" our context service into the constructor
    public UserController(DATABASE context)
    {
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        if (loggedIn)
        {
            return RedirectToAction("All", "Dish");
        }
        return View("Index");
    }

    [HttpGet("/sucess")]
    public IActionResult Success()
    {
        return View("Success");
    }

    [HttpGet("/Login")]
    public IActionResult LoginPage()
    {
        if (loggedIn)
        {
            return RedirectToAction("All", "Dish");
        }
        return View("_Login");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        if (loggedIn)
        {
            return RedirectToAction("All", "Dish");
        }
        return View("_Register");
    }


//---->                   POST                                   


    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (db.Users.Any(user => user.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        }

        if (ModelState.IsValid == false)
        {
            return Register();
        }

        // now we hash our passwords
        PasswordHasher<User> hashy = new PasswordHasher<User>();
        newUser.Password = hashy.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        // now that we've run SaveChanges() we have access to the UserId from our SQL db
        HttpContext.Session.SetInt32("U-ID", newUser.UserId);
        HttpContext.Session.SetString("Name", newUser.FullName());
        // return RedirectToAction("All", "Dish");
        return RedirectToAction("Success");

    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return Register();
        }

        User? dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            // normally login validations should be more generic to avoid phishing
            // but we're using specific error messages for testing
            ModelState.AddModelError("LoginEmail", "not found");
            return Register();
        }

        PasswordHasher<LoginUser> hashy = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashy.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "is not correct");
            return Register();
        }

        // no returns, therefore no errors
        HttpContext.Session.SetInt32("U-ID", dbUser.UserId);
        HttpContext.Session.SetString("Name", dbUser.FullName());
        return RedirectToAction("Success");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Register");
    }
}