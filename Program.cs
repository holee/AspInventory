using Inventory.Data;
using Inventory.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add Services

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

//Add Service by OnConfigure Method

//builder.Services.AddDbContext<ApplicationDbContext>();


///Add Service by Constructor
var connectionString = builder.Configuration.GetConnectionString("MyConection");
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(connectionString);
});


//Configure Request Pineline

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();//controller=Home/action=Index/id?
//app.MapControllerRoute(
//        name:"Home",
//        pattern:"Example/{controller=Item}/{action=Index}/{id?}");





//app.MapControllerRoute(
//        name: "Home1",
//        pattern: "{controller}/{action}/{id:int:min(2):max(100)?}",
//        defaults: new { controller = "Item", action = "Index" });
//app.MapAreaControllerRoute(
//        name: "areas",
//        areaName: "Human",
//        pattern: "{area}/{controller=Humans}/{action=Index}/{id:int?}");

app.Run();


//controller,action,area