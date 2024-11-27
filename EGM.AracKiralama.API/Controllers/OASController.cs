using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    //[Authorize(Roles ="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OASController : ControllerBase
    {
        IOASService _service;
        public OASController(IOASService service)
        {
            _service = service;
        }


        [HttpGet("getperonellist")]
        public async Task<IActionResult> GetGetPersonelListAsync()
        {            
            var data = await _service.GetPersonelList();
            return Ok(data);
        }
     



    }

}
