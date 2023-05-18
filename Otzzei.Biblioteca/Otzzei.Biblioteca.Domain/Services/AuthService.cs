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
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        public AuthService(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result> CreateAccountPasswordAsync(string email, CreatePasswordRequest request)
        {
            var user = await GetUserByEmail(email);
            if (user == null) return Result.Fail("User not found!");

            var add = _userManager.AddPasswordAsync(user, request.Password).ToResult();
            if (add.IsFailed) return Result.Fail("failed to register password");

            return Result.Ok().WithSuccess("successfully registered password!");
        }
        private async Task<IdentityUser<Guid>> GetUserByEmail(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email); 
        }
    }
}
