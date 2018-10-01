using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManagment.Services.Contracts
{
  public interface IDatabaseService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(Guid id);
        Task<T> Create(T item);
        Task Delete(Guid id);
    }
}