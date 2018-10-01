using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;
using DataManagment.Services.Contracts;
using DataManagment.Database.Contracts;

namespace DataManagment.Services
{
  public class AuthorService : IAuthorService
    {
        public IApplicationContext _AppContext { get; }

        public AuthorService(IApplicationContext appContext)
        {
            _AppContext = appContext;
        }

        public Task<IEnumerable<Author>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> FindByName(string name)
        {
            return await _AppContext.Authors.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Author> Create(Author item)
        {
            _AppContext.Authors.Add(item);
            await _AppContext.SaveAsync();
            return item;
        }

        public async Task Delete(Author item)
        {
            _AppContext.Authors.Remove(item);
            await _AppContext.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var author = _AppContext.Authors.FirstOrDefault(a => a.Id == id);
            await Delete(author);
        }
    }
}