using AutoMapper;
using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infra.Model.Dtos;
using Infrastructure.Attributes;
using Infrastructure.Cache;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.OutputCaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Concretes
{
    public class VehicleService : IVehicleService
    {
        private readonly IAracKiralamaRepository _aracKiralamaRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public VehicleService(IAracKiralamaRepository aracKiralamaRepository, IMapper mapper, ICacheService cacheService)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        [Cache("VehicleList",300)]
        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {           

            var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d=>d.StatusId != 0);
                    
            return data;
        }
        public async Task<VehicleDetailDto> GetActiveVehicle(string plate)
        {
            //if
            //throw new Saat20SonrasiException("Araç sorgulamada 20:00 sonrası işlem yapmaya çalıştı.");


            var data = await _aracKiralamaRepository.GetFromSqlAsync<Vehicle>($"select * from Vehicle where  Plate = '{plate}'");
                //await _aracKiralamaRepository.GetProjectAsync<Vehicle,VehicleDetailDto>(d=>d.Plate == plate);

            return _mapper.Map<VehicleDetailDto>(data);
        }
        public async Task<ResultDto<VehicleFormDto>> AddVehicle(VehicleFormDto item)
        {
            var data = _mapper.Map<Vehicle>(item);
            await _aracKiralamaRepository.AddAsync(data);
            await _aracKiralamaRepository.SaveChangesAsync();

            item.Id = data.Id;

            return ResultDto<VehicleFormDto>.Success(item);
        }

    }
}
