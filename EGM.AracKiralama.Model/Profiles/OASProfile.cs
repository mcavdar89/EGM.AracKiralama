using AutoMapper;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Profiles
{
    public class OASProfile : Profile
    {
        public OASProfile()
        {

            //CreateMap<Vehicle, VehicleListDto>()
            //    .ForMember(dest => dest.BrandAd, opt => opt.MapFrom(src => src.Brand.Name))
            //    .ForMember(dest => dest.ModelAd, opt => opt.MapFrom(src => src.Model.Name))
            //;

            CreateMap<Personel, PersonelListDto>()
               .ForMember(dest => dest.UnvanAd, opt => opt.MapFrom(src => src.Birim.Ad))
               .ForMember(dest => dest.BirimAd, opt => opt.MapFrom(src => src.Unvan.Ad))
               .ForMember(dest => dest.SepetUrunSayisi, opt => opt.MapFrom(src => src.PersonelSepet.PersonelSepetUrunList.Count()))

           ;

            CreateMap<PersonelSepetUrun, PersonelSepetUrunDto>()
             .ForMember(dest => dest.UrunAd, opt => opt.MapFrom(src => src.Urun.Ad))
            ;
            CreateMap<PersonelSepetUrunDto, PersonelSepetUrun>();

            CreateMap<PersonelSepet, PersonelSepetDto>()
           .ForMember(dest => dest.PersonelIsim, opt => opt.MapFrom(src => $"{src.Personel.Ad} {src.Personel.Soyad}" ))
          ;
            CreateMap<PersonelSepetDto, PersonelSepet>();
            CreateMap<Urun, UrunDto>().ReverseMap();



            CreateMap<Market, MarketDto>();
            CreateMap<MarketUrun, MarketUrunDto>()
             .ForMember(dest => dest.UrunAd, opt => opt.MapFrom(src => src.Urun.Ad))
                ;
            CreateMap<MarketUrunDto, MarketUrun >();


            CreateMap<MiktarTur, MiktarTurDto>();


        }






    }
}
