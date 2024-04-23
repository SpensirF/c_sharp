using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MeetUpCenter.Models;

namespace MeetUpCenter.Controllers;

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
    
    private MeetUpCenterContext DATABASE;

    public UserController(MeetUpCenterContext context)
    {
        DATABASE = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        if(loggedIn)
        {
            return RedirectToAction("Dashboard", "MeetUp");
        }
        return View("Index");
    }




//---->                   POST                                   

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (DATABASE.Users.Any(user => user.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        if (ModelState.IsValid == false)
        {
            return View("Index");
        }
            // now we hash our passwords
            PasswordHasher<User> hashy = new PasswordHasher<User>();
            newUser.Password = hashy.HashPassword(newUser, newUser.Password);
            DATABASE.Add(newUser);
            DATABASE.SaveChanges();
            // now that we've run SaveChanges() we have access to the UserId from our SQL db
            HttpContext.Session.SetInt32("U-ID", newUser.UserId);
            return RedirectToAction("Dashboard", "Meetup");
        }
        return View("Index");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            return View("Index");
        }

        User? dbUser = DATABASE.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            // normally login validations should be more generic to avoid phishing
            // but we're using specific error messages for testing
            ModelState.AddModelError("LoginEmail", "not found");
            return View("Index");
        }

        PasswordHasher<LoginUser> hashy = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hashy.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "is not correct");
            return View("Index");
        }

        // no returns, therefore no errors
        HttpContext.Session.SetInt32("U-ID", dbUser.UserId);
        return RedirectToAction("Dashboard", "Meetup");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }








}