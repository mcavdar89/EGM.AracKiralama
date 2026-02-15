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
    public class VehicleController : ControllerBase
    {
        IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("getvehiles")]
        public async Task<IActionResult> GetActiveVehiclesAsync()
        {            
            var data = await _service.GetActiveVehicles();
            return Ok(data);
        }
        [HttpGet("getvehile/{id}")]
        public async Task<IActionResult> GetActiveVehicleAsync([FromRoute]int id)
        {
            var data = await _service.GetActiveVehicle(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleFormDto vehicle)
        {
            var result =await _service.AddVehicle(vehicle);
            return Ok(result);
        }



    }

}
