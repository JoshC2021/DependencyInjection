using AutoGenerate.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// IMPORTANT STEPS FOR DEPENDENCY INJECTION
// *********************************************************************************************************************************

// add connection string, this Connection string to the table is wrote in appsetting.json
// The string information matches the connection in your context, for mine it is at line 117, in the OnConfiguring method
string connstring = builder.Configuration.GetConnectionString("db");

// Then you use this line to get your controller talking to the table
// This will allow your controller to take in the context as a parameter
builder.Services.AddDbContext<CoffeeProductsContext>(options => options.UseSqlServer(connstring));

// **********************************************************************************************************************************

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

app.Run();
