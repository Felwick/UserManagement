using Microsoft.EntityFrameworkCore;
using UserManagement.Data;
using Microsoft.AspNetCore.Identity;
using UserManagement.Models;
using UserManagement;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<UserManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserManagementApp")));
        builder.Services.ConfigureDI();
        builder.Services.ConfigureIdentity();
        builder.Services.AddAuthentication();
        builder.Services.ConfigureCookiePolicy();
        builder.Services.ConfigureAntiforgery();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();
        app.UseStatusCodePages();
        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}