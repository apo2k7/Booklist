﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Models.Identity;
using DataManagment.Database;
using DataManagment.Services;
using DataManagment.Services.Contracts;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
  public static class ServiceCollectionExtension
  {
    public static void ConfigureIdentity(this IServiceCollection services)
    {
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

    public static void AddDbContexts(this IServiceCollection services, IConfiguration config){
      var dbConfig = "Dev";
      if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
      {
        dbConfig = "Prod";
      }

      //Connect to Dev or Prod DB
      services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(config.GetConnectionString(dbConfig), x => x.MigrationsAssembly("Booklist")));

      // Automatically perform database migration
      services.BuildServiceProvider().GetService<ApplicationContext>().Database.Migrate();
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
