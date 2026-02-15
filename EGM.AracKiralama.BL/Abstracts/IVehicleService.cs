using EGM.AracKiralama.Model.Dtos;
using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Abstracts
{
    public interface IVehicleService
    {
        Task<List<VehicleListDto>> GetActiveVehicles();
        Task<VehicleListDto> GetActiveVehicle(int id);
        Task<ResultDto<VehicleFormDto>> AddVehicle(VehicleFormDto item);
    }
}
