using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagment.Database.Contracts;
using DataManagment.Services.Contracts;
using Models;

namespace DataManagment.Services
{
  public class PublisherService : IPublisherService
    {
        private IApplicationContext _AppContext;

        public PublisherService(IApplicationContext appContext)
        {
            _AppContext = appContext;
        }
        public Task<Publisher> Create(Publisher item)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> Create(string name)
        {
            var publisher = new Publisher
            {
                Name = name,
                CreatedOn = new DateTime()
            };
            await _AppContext.Publishers.AddAsync(publisher);
            return publisher;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Publisher>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Publisher> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Publisher FindByName(string name)
        {
            return _AppContext.Publishers
                    .Where(p => p.Name == name)
                    .FirstOrDefault();
        }
    }
}