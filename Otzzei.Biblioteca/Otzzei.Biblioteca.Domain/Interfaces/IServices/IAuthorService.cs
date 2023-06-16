using FluentResults;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IServices
{
    public interface IAuthorService
    {
        Task<Result<AuthorResponse>> CreateAuthorAsync(AuthorRequest request);
        Task<Result<AuthorResponse>> UpdateAuthorAsync(Guid id, AuthorRequest request);
        Task<Result<AuthorResponse>> GetAuthorByIdAsync(Guid id);
        Task<Result<List<AuthorResponse>>> GetAllAuthorsAsync();
    }
}
