﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booklist
{
  public class Startup
  {
    private IConfiguration _Config;

    public Startup(IConfiguration config)
    {
      _Config = config;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      //Adding applicatin Services
      services.RegisterServices();

      //Add DbContexts
      services.AddDbContexts(_Config);

      //Configure database Context for Identity
      services.ConfigureIdentity();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if(env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseNodeModules(env.ContentRootPath);
      app.UseAuthentication();

      app.UseMvcRoutes();
    }
  }
}
