using EGM.AracKiralama.Model.Dtos;
using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.BL.Abstracts
{
    public interface IOASService
    {
        Task<List<PersonelListDto>> GetPersonelList();
        Task<ResultDto<PersonelSepetDto>> GetPersonelSepetAsync(int personelId);
        Task<ResultDto<List<UrunDto>>> GetUrunListAsync();
        Task<ResultDto<PersonelSepetDto>> PerosnelSepetOlusturAsync(int personelId);
    }
}
