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

app.MapDefaultControllerRoute();


app.Run();
