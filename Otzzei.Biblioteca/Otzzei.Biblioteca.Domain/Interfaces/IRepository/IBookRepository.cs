using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IRepository
{
    public interface IBookRepository
    {
        Task CreateBookAsync(Book request);
        Task UpdateBookAsync(Book request);
        Task<Book> GetBookByIdAsync(Guid id);
        List<Book> GetAllBooks();
    }
}
