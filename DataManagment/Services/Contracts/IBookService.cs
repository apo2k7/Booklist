using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Identity;
using Models.ViewModels;

namespace DataManagment.Services.Contracts
{
  public interface IBookService : IDatabaseService<Book>
    {
        Task CreateFromViewModel(BookEditViewModel model, ApplicationUser user);
        Task Save(BookEditViewModel model);
        Task<IEnumerable<Book>> GetBooksForUser(Guid id);
    }
}