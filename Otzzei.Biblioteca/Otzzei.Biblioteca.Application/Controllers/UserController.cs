using Microsoft.AspNetCore.Mvc;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;

namespace Otzzei.Biblioteca.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserRequest request)
        {
            var user = await _userService.CreateUserAsync(request);
            if(user.IsSuccess) return Ok(user);
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute]Guid id, [FromBody]UserRequest request)
        {
            var user = await _userService.UpdateUserAsync(id, request);
            if (user.IsSuccess) return Ok(user);
            return BadRequest();
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail([FromQuery]string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user.IsSuccess) return Ok(user);
            return BadRequest();
        }
    }
}
