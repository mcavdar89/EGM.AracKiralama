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
        Task<ResultDto<List<PersonelListDto>>> GetPersonelList();
        Task<ResultDto<PersonelSepetDto>> GetPersonelSepetAsync(int personelId);
        Task<ResultDto<List<UrunDto>>> GetUrunListAsync();
        Task<ResultDto<PersonelSepetDto>> PersonelSepetOlusturAsync(int personelId);
        Task<ResultDto<PersonelSepetDto>> KaydetPersonelSepetAsync(PersonelSepetDto item);
        Task<ResultDto<List<MarketDto>>> GetMarketListAsync();
        Task<ResultDto<List<MarketUrunDto>>> GetMarketUrunListAsync(int marketId);
        Task<ResultDto<MarketUrunDto>> KaydetMarketUrunAsync(MarketUrunDto item);

        Task<ResultDto<List<MiktarTurDto>>> GetMiktarTurListAsync();

        Task<ResultDto<UrunDto>> KaydetUrunAsync(UrunDto item);


        ///test

    }
}
