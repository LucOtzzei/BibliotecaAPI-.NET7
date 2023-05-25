using Microsoft.EntityFrameworkCore;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BibliotecaContext _context;
        public AuthorRepository(BibliotecaContext context)
        {
            _context = context;
        }
        public async Task<Author> CreateAuthorAsync(Author author)
        {
            var create = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var update = _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public async Task<Guid> DeleteAuthorAsync(Author author)
        {
            var delete = _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }
        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Author>> GetAuthorsAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }
    }
}
