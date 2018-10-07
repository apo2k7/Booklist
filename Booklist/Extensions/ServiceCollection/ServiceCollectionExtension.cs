using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Models.Identity;
using DataManagment.Database;
using DataManagment.Services;
using DataManagment.Services.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class ServiceCollectionExtension
  {
    public static void ConfigureIdentity(this IServiceCollection services)
    {
      //services.AddIdentity<ApplicationUser, IdentityRole>()
      //  .AddEntityFrameworkStores<ApplicationContext>()
      //  .AddDefaultTokenProviders()
      //  .AddUserStore<UserStore<ApplicationUser>>()
      //  .AddRoleStore<RoleStore<IdentityRole>>();

      services.AddDefaultIdentity<ApplicationUser>()
              .AddEntityFrameworkStores<ApplicationContext>();

      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 3;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
      });
    }

    public static void AddDbContexts(this IServiceCollection services, Action<DbContextOptionsBuilder> options){
      services.AddDbContext<ApplicationContext>(options);
    }

    public static void RegisterServices(this IServiceCollection services)
    {
      services.AddScoped<IAuthorService, AuthorService>();
      services.AddScoped<IBookService, BookService>();
      services.AddScoped<IPublisherService, PublisherService>();
      services.AddScoped<UserManager<ApplicationUser>>();
      services.AddScoped<SignInManager<ApplicationUser>>();
    }
  }
}
