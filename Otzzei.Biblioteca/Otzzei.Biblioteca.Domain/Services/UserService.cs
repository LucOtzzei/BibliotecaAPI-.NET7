using FluentResults;
using Microsoft.AspNetCore.Identity;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        public async Task<Result<IdentityUser<Guid>>> CreateUserAsync(UserRequest request)
        {
            var user = new IdentityUser<Guid>() { Email = request.Email, UserName = request.Email };
            var create = await _userManager.CreateAsync(user);
            if (create.Succeeded) return Result.Ok(user);
            return Result.Fail("Falha ao criar um usuario!");
        }
    }
}
