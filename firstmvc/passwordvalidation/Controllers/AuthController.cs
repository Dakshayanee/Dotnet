using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using passwordvalidation.Models;
namespace passwordvalidation.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }
 
public IActionResult Login()
    {

        Console.WriteLine("in login method");
        return View();
    }
    public IActionResult Welcome()
    {

       // Console.WriteLine("in login method");
        return View();
    }

    public IActionResult Register()
    {
        Console.WriteLine("in register method");
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}