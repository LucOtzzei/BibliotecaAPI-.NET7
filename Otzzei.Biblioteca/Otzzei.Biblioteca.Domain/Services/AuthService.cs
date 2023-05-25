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
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        public AuthService(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<Result> CreateAccountPasswordAsync(string email, CreatePasswordRequest request)
        {
            var user = await GetUserByEmail(email);
            if (user == null) return Result.Fail("User not found!");

            var add = await _userManager.AddPasswordAsync(user, request.Password);
            if (add.Succeeded) return Result.Ok().WithSuccess("Account password successfully registered!");
            return Result.Fail("failed to register account password");
        }
        public async Task<Result> LoginAsync(LoginRequest request)
        {
            var user = await GetUserByEmail(request.Email);
            if (user == null) return Result.Fail("User not found");

            var login = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (login.Succeeded) return Result.Ok().WithSuccess("Successfully log-in");
            return Result.Fail("Failed to login");
        }

        private async Task<IdentityUser<Guid>> GetUserByEmail(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email); 
        }
    }
}
