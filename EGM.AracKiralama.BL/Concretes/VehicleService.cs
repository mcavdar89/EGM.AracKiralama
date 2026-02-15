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
        public VehicleService(IAracKiralamaRepository aracKiralamaRepository, IMapper mapper)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
            _mapper = mapper;
        }

        [Cache("VehicleList", 300)]
        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {

            // var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d=>d.StatusId != 0);
            var data = new List<VehicleListDto>() {                 
                new VehicleListDto(){ Id=1,BrandAd="Renault",ModelAd="Clio",Plate="34ABC34" },
                new VehicleListDto(){ Id=2,BrandAd="Fiat",ModelAd="Egea",Plate="34DEF34" },
                new VehicleListDto(){ Id=3,BrandAd="Volkswagen",ModelAd="Passat",Plate="34GHI34" },
                new VehicleListDto(){ Id=4,BrandAd="Ford",ModelAd="Focus",Plate="34JKL34" },
                new VehicleListDto(){ Id=5,BrandAd="Opel",ModelAd="Astra",Plate="34MNO34" },
                new VehicleListDto(){ Id=6,BrandAd="Hyundai",ModelAd="i20",Plate="34PQR34" },
                new VehicleListDto(){ Id=7,BrandAd="Toyota",ModelAd="Corolla",Plate="34STU34" },
                new VehicleListDto(){ Id=8,BrandAd="Honda",ModelAd="Civic",Plate="34VWX34" },
                new VehicleListDto(){ Id=9,BrandAd="Mazda",ModelAd="3",Plate="34YZA34" },
                new VehicleListDto(){ Id=10,BrandAd="Nissan",ModelAd="Qashqai",Plate="34BCD34" }
            };

            return data;
        }
        public async Task<VehicleListDto> GetActiveVehicle(int id)
        {

            var list = new List<VehicleListDto>() {
                new VehicleListDto(){ Id=1,BrandAd="Renault",ModelAd="Clio",Plate="34ABC34" },
                new VehicleListDto(){ Id=2,BrandAd="Fiat",ModelAd="Egea",Plate="34DEF34" },
                new VehicleListDto(){ Id=3,BrandAd="Volkswagen",ModelAd="Passat",Plate="34GHI34" },
                new VehicleListDto(){ Id=4,BrandAd="Ford",ModelAd="Focus",Plate="34JKL34" },
                new VehicleListDto(){ Id=5,BrandAd="Opel",ModelAd="Astra",Plate="34MNO34" },
                new VehicleListDto(){ Id=6,BrandAd="Hyundai",ModelAd="i20",Plate="34PQR34" },
                new VehicleListDto(){ Id=7,BrandAd="Toyota",ModelAd="Corolla",Plate="34STU34" },
                new VehicleListDto(){ Id=8,BrandAd="Honda",ModelAd="Civic",Plate="34VWX34" },
                new VehicleListDto(){ Id=9,BrandAd="Mazda",ModelAd="3",Plate="34YZA34" },
                new VehicleListDto(){ Id=10,BrandAd="Nissan",ModelAd="Qashqai",Plate="34BCD34" }
            };


            var data = list.FirstOrDefault(d => d.Id == id);



            //if
            //throw new Saat20SonrasiException("Araç sorgulamada 20:00 sonrası işlem yapmaya çalıştı.");


            //var data = await _aracKiralamaRepository.GetFromSqlAsync<Vehicle>($"select * from Vehicle where  Plate = '{plate}'");
            //await _aracKiralamaRepository.GetProjectAsync<Vehicle,VehicleDetailDto>(d=>d.Plate == plate);




            //return _mapper.Map<VehicleDetailDto>(data);
            return ResultDto<VehicleListDto>.Success(data); ;
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
