//Author: Group 6
//When: July 2023

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication( //added for cookies authentication
            CookieAuthenticationDefaults.AuthenticationScheme).
            AddCookie(opt => opt.LoginPath = "/Account/Login");// Account controller, Login method 
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews();

//db injection
builder.Services.AddDbContext<TravelExpertsContext>(options =>
           options.UseSqlServer(
               builder.Configuration.GetConnectionString("TravelExpertsConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // added for authentication
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
