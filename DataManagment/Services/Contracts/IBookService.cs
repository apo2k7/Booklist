using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.ViewModels;

namespace DataManagment.Services.Contracts
{
  public interface IBookService : IDatabaseService<Book>
    {
        Task CreateFromViewModel(BookEditViewModel model, IdentityUser user);
        Task Save(BookEditViewModel model);
        Task<IEnumerable<Book>> GetBooksForUser(Guid id);
    }
}