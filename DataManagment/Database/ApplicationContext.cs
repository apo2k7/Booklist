using Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;

namespace DataManagment.Database
{

  public class ApplicationContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Author> Authors { get; private set; }
    public DbSet<Book> Books { get; private set; }
    public DbSet<Publisher> Publishers { get; private set; }

    public ApplicationContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.HasDefaultSchema("App");

      //builder.Entity<ApplicationUser>(b =>
      //{
      //  b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
      //});
      //
      //builder.Entity<ApplicationRole>(b =>
      //{
      //  b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
      //});
      
      builder.ConfigureBookAuthors();
      builder.ConfigureBookGenres();  
    }

    public async Task SaveAsync()
    {
      await SaveChangesAsync();
      return;
    }
  }
}
