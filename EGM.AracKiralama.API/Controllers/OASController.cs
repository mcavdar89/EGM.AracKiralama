using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EGM.AracKiralama.API.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OASController : ControllerBase
    {
        IOASService _service;
        public OASController(IOASService service)
        {
            _service = service;
        }


        [HttpGet("getpersonellist")]
        public async Task<IActionResult> GetPersonelListAsync()
        {            
            var data = await _service.GetPersonelList();
            return Ok(data);
        }

        [HttpGet("getpersonelsepet/{personelId}")]
        public async Task<IActionResult> GetPersonelSepetAsync([FromRoute] int personelId)
        {
            var data = await _service.GetPersonelSepetAsync(personelId);
            return Ok(data);
        }

        [HttpGet("geturunlistfordropdown")]
        public async Task<IActionResult> GetUrunListAsync()
        {
            var data = await _service.GetUrunListAsync();
            return Ok(data);
        }


        [HttpPost("kaydetpersonelsepet")]
        public async Task<IActionResult> KaydetPersonelSepetAsync([FromBody]PersonelSepetDto item)
        {
            var data = await _service.KaydetPersonelSepetAsync(item);
            return Ok(data);
        }

        [HttpGet("getmarketlist")]
        public async Task<IActionResult> GetMarketListAsync()
        {
            var data = await _service.GetMarketListAsync();
            return Ok(data);
        }
        [HttpGet("getmarketurunlist/{marketId}")]
        public async Task<IActionResult> GetMarketUrunListAsync([FromRoute] int marketId)
        {
            var data = await _service.GetMarketUrunListAsync(marketId);
            return Ok(data);
        }

        [HttpPost("kaydetmarketurun")]
        public async Task<IActionResult> KaydetMarketUrunAsync([FromBody] MarketUrunDto item)
        {
            var data = await _service.KaydetMarketUrunAsync(item);
            return Ok(data);
        }



        [HttpGet("getmiktarturlistfordropdown")]
        public async Task<IActionResult> GetMiktarTurListAsync()
        {
            var data = await _service.GetMiktarTurListAsync();
            return Ok(data);
        }

        [HttpPost("kaydeturun")]
        public async Task<IActionResult> KaydetUrunAsync([FromBody]UrunDto urun)
        {
            var data = await _service.KaydetUrunAsync(urun);
            return Ok(data);
        }


    }

}
