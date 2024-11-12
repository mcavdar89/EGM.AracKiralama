using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using Infra.Model.Dtos;
using Infrastructure.Model.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login([FromBody]LoginDto item)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ResultDto<JwtDto>.Error("Geçerli bir model değil"));
            }
            var result = await _service.LoginAsync(item);

            return Ok(result);
        }

    }
}
