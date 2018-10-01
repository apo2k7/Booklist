using Models;
using System.Threading.Tasks;

namespace DataManagment.Services.Contracts
{
  public interface IAuthorService : IDatabaseService<Author>
    {
        Task<Author> FindByName(string name);
    }
}