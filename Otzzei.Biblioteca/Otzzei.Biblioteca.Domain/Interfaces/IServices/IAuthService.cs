using FluentResults;
using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<Result> CreateAccountPasswordAsync(string email, CreatePasswordRequest request);
    }
}
