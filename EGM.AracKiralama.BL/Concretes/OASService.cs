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

        public async Task<List<PersonelListDto>> GetPersonelList()
        {

            var data = await _repository.ListProjectAsync<Personel, PersonelListDto>(d => d.StatusId != 0);

            return data;
        }
        public async Task<ResultDto<PersonelSepetDto>> GetPersonelSepetAsync(int personelId)
        {

            var data = await _repository.GetProjectAsync<PersonelSepet, PersonelSepetDto>(d => d.StatusId != 0 && d.PersonelId == personelId);

            if (data == null)
            {
                return await PerosnelSepetOlusturAsync(personelId);
            }

            return ResultDto<PersonelSepetDto>.Success(data);
        }
        public async Task<ResultDto<List<UrunDto>>> GetUrunListAsync()
        {

            var data = await _repository.ListProjectAsync<Urun, UrunDto>(d => d.StatusId != 0);
            return ResultDto<List<UrunDto>>.Success(data);
        }

        public async Task<ResultDto<PersonelSepetDto>> PerosnelSepetOlusturAsync(int personelId)
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


    }
}
