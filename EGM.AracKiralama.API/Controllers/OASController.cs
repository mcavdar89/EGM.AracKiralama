﻿using EGM.AracKiralama.BL.Abstracts;
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


    }

}
