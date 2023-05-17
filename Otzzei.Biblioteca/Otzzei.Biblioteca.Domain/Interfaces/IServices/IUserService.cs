using FluentResults;
using Microsoft.AspNetCore.Identity;
using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IServices
{
    public interface IUserService
    {
        Task<Result<IdentityUser<Guid>>> CreateUserAsync(UserRequest request);
    }
}
