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


        [HttpGet("getvehiles")]
        public async Task<IActionResult> GetActiveVehiclesAsync()
        {            
            var data = await _service.GetActiveVehicles();
            return Ok(data);
        }
        [HttpGet("getvehile/{plate}")]
        public async Task<IActionResult> GetActiveVehicleAsync([FromRoute]string plate)
        {
            var data = await _service.GetActiveVehicle(plate);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleFormDto vehicle)
        {
            var result =await _service.AddVehicle(vehicle);
            return Ok(result);
        }


        void islem1()
        {
            Deger deger = new(); 

            deger.a = 5;

            islem2(deger);

            Console.WriteLine(deger.a);


        }

        void islem2(Deger deger)
        {
             deger.a += 7;
        }






    }


    public class Deger
    {
       public int a { get; set;}


}
