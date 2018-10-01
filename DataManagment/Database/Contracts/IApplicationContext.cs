using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataManagment.Database.Contracts
{
  public interface IApplicationContext
    {
        DbSet<Book> Books { get; }
        DbSet<Author> Authors { get; }
        DbSet<Publisher> Publishers { get; }

        Task SaveAsync();
    }
}