namespace passwordvalidation.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class EmployeeManager{


    public static List<Employee> GetAllEmployees(){
        // List<Employee> emp = new List<Employee>();
        // emp.Add( new Employee(){ FirstName="Ravi", LastName="Tambade", Email="rTambade@gmail.com", ContactNumber="35434", Password="ravi@123"});
        // emp.Add( new Employee(){ FirstName="Sachin", LastName="Nene", Email="", ContactNumber="sNene@gmail.com", Password="sachin@123"});
        // emp.Add( new Employee(){ FirstName="Shivani", LastName="Pande", Email="sPande@gmail.com", ContactNumber="56565464", Password="shivani@123"});
        // emp.Add( new Employee(){ FirstName="Madhu", LastName="Sharma", Email="mSharma@gmail.com", ContactNumber="342345", Password="madhu@123"});
        List<Employee> jsonEmployees = null;
        try{
            // // dynamic data type variable
            // var options=new JsonSerializerOptions {IncludeFields=true};
            // var produtsJson=JsonSerializer.Serialize<List<Employee>>(emp,options);
            // string fileName=@"D:\JAVA_SD\DotNet\dotnet\employee.json";
            // //Serialize all Flowers into json file

            // File.WriteAllText(fileName,produtsJson);
            //Deserialize from JSON file
            string fileName=@"D:\JAVA_SD\DotNet\dotnet\employee.json";
            string jsonString = File.ReadAllText(fileName);
            jsonEmployees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n JSON :Deserializing data from json file\n \n");
              
    }
   catch(Exception exp){
    
    }
    finally{ }


        return jsonEmployees;
    }
}