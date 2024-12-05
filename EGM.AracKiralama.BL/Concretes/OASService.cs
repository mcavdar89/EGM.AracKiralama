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
    public class OASService : IOASService
    {
        private readonly IAracKiralamaRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public OASService(IAracKiralamaRepository aracKiralamaRepository, IMapper mapper, ICacheService cacheService)
        {
            _repository = aracKiralamaRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<ResultDto<List<PersonelListDto>>> GetPersonelList()
        {

            var data = await _repository.ListProjectAsync<Personel, PersonelListDto>(d => d.StatusId != 0);

            return ResultDto<List<PersonelListDto>>.Success(data);
        }
        public async Task<ResultDto<PersonelSepetDto>> GetPersonelSepetAsync(int personelId)
        {

            var data = await _repository.GetProjectAsync<PersonelSepet, PersonelSepetDto>(d => d.StatusId != 0 && d.PersonelId == personelId);

            if (data == null)
            {
                return await PersonelSepetOlusturAsync(personelId);
            }

            return ResultDto<PersonelSepetDto>.Success(data);
        }
        public async Task<ResultDto<List<UrunDto>>> GetUrunListAsync()
        {

            var data = await _repository.ListProjectAsync<Urun, UrunDto>(d => d.StatusId != 0);
            return ResultDto<List<UrunDto>>.Success(data);
        }

        public async Task<ResultDto<PersonelSepetDto>> PersonelSepetOlusturAsync(int personelId)
        {
            var data = new PersonelSepet()
            {
                Id = Guid.NewGuid(),
                PersonelId = personelId,
                LastTransactionDate = DateTime.Now
            };
            await _repository.AddAsync(data);
            await _repository.SaveChangesAsync();

            return await GetPersonelSepetAsync(personelId);
        }

        public async Task<ResultDto<PersonelSepetDto>> KaydetPersonelSepetAsync(PersonelSepetDto item)
        {
            var kayitliList = await _repository.ListAsync<PersonelSepetUrun>(d => d.PersonelSepetId == item.Id);

            _repository.DeleteRange(kayitliList, true);
            await _repository.SaveChangesAsync();

            var data = _mapper.Map<List<PersonelSepetUrun>>(item.PersonelSepetUrunList);

            foreach (var item2 in data)
            {
                item2.LastTransactionDate = DateTime.Now;
            }

            await _repository.AddRangeAsync(data);
            await _repository.SaveChangesAsync();

            return ResultDto<PersonelSepetDto>.Success(item, "Kaydetme işlemi başarılı");
        }

        public async Task<ResultDto<List<MarketDto>>> GetMarketListAsync()
        {

            var data = await _repository.ListProjectAsync<Market, MarketDto>(d => d.StatusId != 0);
            return ResultDto<List<MarketDto>>.Success(data);
        }
        public async Task<ResultDto<List<MarketUrunDto>>> GetMarketUrunListAsync(int marketId)
        {

            var data = await _repository.ListProjectAsync<MarketUrun, MarketUrunDto>(d => d.StatusId != 0 && d.MarketId == marketId);

            return ResultDto<List<MarketUrunDto>>.Success(data);
        }


        public async Task<ResultDto<MarketUrunDto>> KaydetMarketUrunAsync(MarketUrunDto item)
        {

            var data = await _repository.GetAsync<MarketUrun>(d => d.UrunId == item.UrunId);
            if (data == null)
            {
                data = _mapper.Map<MarketUrun>(item);
                data.Id = Guid.NewGuid();
                data.LastTransactionDate = DateTime.Now;
                await _repository.AddAsync(data);
            }
            else
            {
                data.Stok = item.Stok;
                data.Fiyat = item.Fiyat;
                data.LastTransactionDate = DateTime.Now;
                _repository.Update(data);

            }
            await _repository.SaveChangesAsync();
            item.Id = data.Id;

            return ResultDto<MarketUrunDto>.Success(item);
        }


        public async Task<ResultDto<List<MiktarTurDto>>> GetMiktarTurListAsync()
        {

            var data = await _repository.ListProjectAsync<MiktarTur, MiktarTurDto>(d => d.StatusId != 0);

            return ResultDto<List<MiktarTurDto>>.Success(data);
        }


        public async Task<ResultDto<UrunDto>> KaydetUrunAsync(UrunDto item)
        {
            var tempData = await _repository.GetAsync<Urun>(d => d.Ad == item.Ad);
            if (tempData != null)
            {
                return ResultDto<UrunDto>.Error("Aynı ürün zaten kayıtlı");

            }


            var data = _mapper.Map<Urun>(item);
            data.LastTransactionDate = DateTime.Now;
            data.StatusId = 1;
            await _repository.AddAsync(data);
            await _repository.SaveChangesAsync();

            item.Id = data.Id;


            return ResultDto<UrunDto>.Success(item, "Kaydetme işlemi başarılı");
        }



    }
}
