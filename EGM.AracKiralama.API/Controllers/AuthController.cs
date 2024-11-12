using EGM.AracKiralama.Model.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public async Task<IActionResult>Login(LoginDto item)
        {
            return Ok();
        }

    }
}
