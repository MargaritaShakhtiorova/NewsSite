using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Diploma_v1._1.Areas.Identity.Data;
using ApplicationDb;


var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Diploma_v1_1Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Author>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Diploma_v1_1Context>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
