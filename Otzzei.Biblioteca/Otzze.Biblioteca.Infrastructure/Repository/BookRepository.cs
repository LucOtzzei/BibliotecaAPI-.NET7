using Microsoft.EntityFrameworkCore;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BibliotecaContext _context;
        public BookRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task CreateBookAsync(Book request)
        {
            _context.Books.Add(request);
            await _context.SaveChangesAsync();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateBookAsync(Book request)
        {
            _context.Books.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
