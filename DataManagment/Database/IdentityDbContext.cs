using System;
using Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Customize the ASP.NET Identity model and override the defaults if needed.
// For example, you can rename the ASP.NET Identity table names and more.
// Add your customizations after calling base.OnModelCreating(builder);

namespace DataManagment.Database
{

  public class IdentityAppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
  {
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.HasDefaultSchema("Identity");

      builder.Entity<ApplicationUser>(b =>
      {
        b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
      });

      builder.Entity<ApplicationRole>(b =>
      {
        b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
      });
    }
  }
}
