using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
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
        public VehicleService(IAracKiralamaRepository aracKiralamaRepository)
        {
            _aracKiralamaRepository = aracKiralamaRepository;
        }


        public async Task<List<VehicleListDto>> GetActiveVehicles()
        {
            var data = await _aracKiralamaRepository.ListProjectAsync<Vehicle, VehicleListDto>(d=>d.StatusId != 0);

            return data;
        }



    }
}
