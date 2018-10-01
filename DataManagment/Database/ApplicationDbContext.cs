using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataManagment.Database.Contracts;

namespace DataManagment.Database
{
  public class ApplicationDbContext : DbContext, IApplicationContext
  {
    public DbSet<Author> Authors { get; private set; }
    public DbSet<Book> Books { get; private set; }
    public DbSet<Publisher> Publishers { get; private set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
      : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.HasDefaultSchema("App");
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
