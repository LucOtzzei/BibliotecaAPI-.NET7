using FluentResults;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IServices
{
    public interface IBookService
    {
        Task<Result<BookResponse>> CreateBookAsync(BookRequest request);
        Task<Result<BookResponse>> UpdateBookAsync(Guid id, BookRequest request);
        Task<Result<BookResponse>> GetBookByIdAsync(Guid id);
        Task<Result<List<BookResponse>>> GetAllBooksAsync();
    }
}
