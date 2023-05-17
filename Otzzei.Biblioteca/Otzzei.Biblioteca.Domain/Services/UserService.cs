using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public UserService(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<IdentityUser<Guid>>> CreateUserAsync(UserRequest request)
        {
            var user = new IdentityUser<Guid>() { Email = request.Email, UserName = request.Email };
            var create = await _userManager.CreateAsync(user);
            if (create.Succeeded) return Result.Ok(user);
            return Result.Fail("Falha ao criar um usuario!");
        }
        public async Task<Result<IdentityUser<Guid>>> UpdateUserAsync(Guid id, UserRequest request)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var update = await _userManager.UpdateAsync(user);
            if (update.Succeeded) return Result.Ok(user);
            return Result.Fail("Falha ao atualizar o usuario");
        }
        public async Task<Result<IdentityUser<Guid>>> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedEmail  == email.ToUpper());
            if (user != null) return Result.Ok(user);
            return Result.Fail("Falha ao recuperar usuario");
        }
    }
}
