using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
  public static class ApplicationBuilderExtension
  {
    public static void UseMvcRoutes(this IApplicationBuilder app){
      app.UseMvc(routes => 
        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}")
      );
    }

    public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string rootPath)
    {
      app.UseStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(rootPath, "node_modules")),
        RequestPath = "/node_modules"
      });
      return app;
    }
  }
}
