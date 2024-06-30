using Microsoft.AspNetCore.Identity;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services;

namespace UserManagement
{
    public static class ServicesConfigurationExtensions
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {

            services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail= false;
                options.Lockout.AllowedForNewUsers = false;
            })
                .AddEntityFrameworkStores<UserManagementContext>()
                .AddDefaultTokenProviders();

            return services;

        }

        public static IServiceCollection ConfigureCookiePolicy(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Login/AccessDenied";
                options.SlidingExpiration = true;
            });

            return services;
        }

        public static IServiceCollection ConfigureAntiforgery(this IServiceCollection services)
        {             services.AddAntiforgery(options =>
            {
                options.Cookie.Name = "X-CSRF-TOKEN";
                options.FormFieldName = "X-CSRF-TOKEN";
                options.HeaderName = "X-CSRF-TOKEN";
            });

            return services;
        }
        
        public  static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IUserManagementService, UserManagementService>();

            return services;
        }
    }

}
