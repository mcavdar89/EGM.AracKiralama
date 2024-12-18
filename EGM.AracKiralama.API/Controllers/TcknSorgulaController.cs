using Infra.Model.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TcknSorgulaController : ControllerBase
    {
        [HttpGet("{tckn}")]
        public async Task<IActionResult> Sorgula([FromRoute] long tckn)
        {
            var data = "Mustafa çavdaroğlu";

            return Ok(ResultDto<string>.Success(data));
        }

    }
}
