

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


/* var employees=new List<Employee>();
employees.Add( new Employee(){ FirstName="Ravi", LastName="Tambade", Email="rTambade@gmail.com", ContactNo="35434", Password="ravi@123"});
employees.Add( new Employee(){ FirstName="Sachin", LastName="Nene", Email="", ContactNo="sNene@gmail.com", Password="sachin@123"});
employees.Add( new Employee(){ FirstName="Shivani", LastName="Pande", Email="sPande@gmail.com", ContactNo="56565464", Password="shivani@123"});
employees.Add( new Employee(){ FirstName="Madhu", LastName="Sharma", Email="mSharma@gmail.com", ContactNo="342345", Password="madhu@123"}); */

app.MapGet("/home/postregister", () => "Login received");
app.MapGet("/home/postregister", () => "Register received");

app.Run();