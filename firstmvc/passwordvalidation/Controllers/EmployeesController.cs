using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using passwordvalidation.Models;
namespace passwordvalidation.Controllers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class EmployeesController : Controller
{
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(ILogger<EmployeesController> logger)
    {
        _logger = logger;
    }

public IActionResult Postregister(string firstname,string lastname,string contact,string email,string pwd)
    {
        List<Employee> jsonEmployees=null;
         try{
            //Deserialize from JSON file
            string fileName=@"D:\JAVA_SD\DotNet\dotnet\employee.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            jsonEmployees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n JSON :Deserializing data from json file\n \n");

            //adding new employee into list
            jsonEmployees.Add(new Employee() {FirstName=firstname, LastName=lastname, Email=email, ContactNumber=contact, Password=pwd});

             //Serialize all Flowers into json file
            var options=new JsonSerializerOptions {IncludeFields=true};
            var produtsJson=JsonSerializer.Serialize<List<Employee>>(jsonEmployees,options);
            System.IO.File.WriteAllText(fileName,produtsJson);
            Console.WriteLine("Employee registered successfully, check once");

            return Redirect("/employees/Index");
    }
   catch(Exception exp){
    
    }
    finally{ }


        return View();
    }

    
     public IActionResult Postlogin(string email,string password)

    {
        try{
            //Deserialize from JSON file
            string fileName=@"D:\JAVA_SD\DotNet\dotnet\employee.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            List<Employee> jsonEmployees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n JSON :Deserializing data from json file\n \n");

        foreach( Employee employee in jsonEmployees){
            if(email == employee.Email && 
                                password==employee.Password){
             Console.WriteLine("successfull validation of employee..... ");
             Console.WriteLine("Redirecting to welcome..... ");   
            return Redirect("/Auth/Welcome");
           }
        }
    }
   catch(Exception exp){
    
    }
    finally{ }

        return View();
    }

    public IActionResult Index(){
        List<Employee>  allEmployees=EmployeeManager.GetAllEmployees();
        ViewData["catalog"]=allEmployees;
         return View();
    }

    
}