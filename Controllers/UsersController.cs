using Demo_Web_API.Models.DTOs;
using Demo_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _userService.RegisterUserAsync(dto);
                return Ok(new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("obtener")]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                var usuarios = await _userService.Obtener();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error al obtener usuarios", Error = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            try
            {
                var user = await _userService.UpdateUserAsync(dto);
                return Ok(new
                {
                    message = "Usuario actualizado con éxito",
                    user.Id,
                    user.UserName,
                    user.Email
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPut("updateemail")]
        public async Task<IActionResult> UpdateEmail(UpdateEmailUserDto dto)
        {
            try
            {
                var user = await _userService.UpdateEmailAsync(dto);
                return Ok(new
                {
                    message = "Email actualizado con éxito",
                    user.Id,
                    user.UserName,
                    user.Email
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(new { message = "Usuario eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        
    }
}