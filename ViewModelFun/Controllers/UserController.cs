using Microsoft.AspNetCore.Mvc;


namespace ViewModelFun.Controllers;
public class UserController : Controller
{
    [HttpGet("")]

    public IActionResult Index()
    {
        string message = "Random message goes here";
        return View("Index", message);
    }

    [HttpGet("Numbers")]
    public IActionResult Numbers()
    {
        int[] numbers = new int[]
        {
            1,2,3,10,43,5
        };
        return View("numbers");
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        List<User> users = new List<User>();
        users.Add(new User("Moose", "Phillips"));
        users.Add(new User("Sarah"));
        users.Add(new User("Jerry"));
        users.Add(new User("Renee", "Ricky"));
        users.Add(new User("Barbara"));

        return View(users);
    }
    [HttpGet("user")]
    public IActionResult OneUser()
    {
        User firstUser = new User("Moose", "Phillips");
        return View(firstUser);
    }
}




