using FluentResults;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Result<AuthorResponse>> CreateAuthorAsync(AuthorRequest request)
        {
            var author = new Author(request);
            var created = await _authorRepository.CreateAuthorAsync(author);

            var result = new AuthorResponse(author);
            return Result.Ok(result);
        }
        public async Task<Result<AuthorResponse>> UpdateAuthorAsync(Guid id, AuthorRequest request)
        {
            var author = await _authorRepository.GetAuthorById(id);

            author.Update(request);
            var update = await _authorRepository.UpdateAuthorAsync(author);

            var result = new AuthorResponse(update);
            return Result.Ok(result);
        }
        public async Task<Result<List<AuthorResponse>>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAuthorsAsync();
            return Result.Ok(authors.Select(x => new AuthorResponse(x)).ToList());
        }
        public async Task<Result<AuthorResponse>> GetAuthorByIdAsync(Guid id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            var result = new AuthorResponse(author);

            return Result.Ok(result);
        }    
    }
}
