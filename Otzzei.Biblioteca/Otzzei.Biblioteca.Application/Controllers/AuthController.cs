using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;

namespace Otzzei.Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPatch("{email}")]
        public async Task<IActionResult> CreateAccountPasswordAsync([FromRoute]string email, [FromBody]CreatePasswordRequest request)
        {
            var create = await _authService.CreateAccountPasswordAsync(email, request);
            if (create.IsFailed) return NotFound(create);
            return Ok(create);
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var login = await _authService.LoginAsync(request);
            if (login.IsFailed) return BadRequest(login);
            return Ok(login);
        }
    }
}
