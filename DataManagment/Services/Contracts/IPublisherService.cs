using Models;
using System.Threading.Tasks;

namespace DataManagment.Services.Contracts
{
  public interface IPublisherService : IDatabaseService<Publisher>
    {
        Task<Publisher> Create(string name);
        Publisher FindByName(string publisherName);
    }
}