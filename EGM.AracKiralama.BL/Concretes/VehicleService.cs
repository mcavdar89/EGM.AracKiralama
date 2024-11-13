﻿using AutoMapper;
using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Concretes
{
    public class VehicleService:IVehicleService
    {
        private readonly IAracKiralamaRepository _aracKiralamaRepository;
        private readonly IMapper _mapper;
        public VehicleService(IAracKiralamaRepository aracKiralamaRepository,IMapper mapper)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
            _mapper = mapper;
        }


        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {
            var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d=>d.StatusId != 0);

            return data;
        }
        public async Task<VehicleDetailDto> GetActiveVehicle(string plate)
        {
            var data = await _aracKiralamaRepository.GetProjectAsync<Vehicle,VehicleDetailDto>(d=>d.Plate == plate);

            return data;
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
