using EGM.AracKiralama.BL.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            _service = service;
        }


        [HttpGet("getvehiles")]
        public async Task<IActionResult> GetActiveVehiclesAsync()
        {            
            var data = await _service.GetActiveVehicles();
            return Ok(data);
        }
    }
}
