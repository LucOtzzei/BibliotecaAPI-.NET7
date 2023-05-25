using Otzzei.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IRepository
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<Guid> DeleteAuthorAsync(Author author);
        Task<Author> GetAuthorById(Guid id);
        Task<List<Author>> GetAuthorsAsync();
    }
}
