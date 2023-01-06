using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using passwordvalidation.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using HR;

namespace passwordvalidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {

        Console.WriteLine("in login method");
        return View();
    }

    public IActionResult Register()
    {
        Console.WriteLine("in register method");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Postregister(string firstname,string lastname,string contact,string email,string pwd)
    {
        List<Employee> emp=new List<Employee>();
        emp.Add( new Employee(){ FirstName="Ravi", LastName="Tambade", Email="rTambade@gmail.com", ContactNo="35434", Password="ravi@123"});
        emp.Add( new Employee(){ FirstName="Sachin", LastName="Nene", Email="", ContactNo="sNene@gmail.com", Password="sachin@123"});
        emp.Add( new Employee(){ FirstName="Shivani", LastName="Pande", Email="sPande@gmail.com", ContactNo="56565464", Password="shivani@123"});
        emp.Add( new Employee(){ FirstName="Madhu", LastName="Sharma", Email="mSharma@gmail.com", ContactNo="342345", Password="madhu@123"});

         try{
            // dynamic data type variable
            var options=new JsonSerializerOptions {IncludeFields=true};
            var produtsJson=JsonSerializer.Serialize<List<Employee>>(emp,options);
            string fileName=@"D:\JAVA_SD\DotNet\dotnet\employee.json";
            //Serialize all Flowers into json file

            File.WriteAllText(fileName,produtsJson);
            //Deserialize from JSON file
            string jsonString = File.ReadAllText(fileName);
            List<Employee> jsonFlowers = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n JSON :Deserializing data from json file\n \n");
            foreach( Employee flower in jsonFlowers)
            {
                Console.WriteLine($"{flower.FirstName} : {flower.LastName} : {flower.Email} : {flower.ContactNo} : {flower.Password}");   
            }   
    }
   catch(Exception exp){
    
    }
    finally{ }


        return View();
    }

    
     public IActionResult Postlogin(string email,string password)

    {
        Console.WriteLine("email="+email+"password="+password);
         
         Console.WriteLine("in Postlogin method");

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
