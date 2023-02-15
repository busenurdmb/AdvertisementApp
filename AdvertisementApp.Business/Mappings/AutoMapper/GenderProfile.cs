using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Mappings.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<GenderCreateDtos, Gender>().ReverseMap();
            CreateMap<GenderUpdateDtos, Gender>().ReverseMap();
            CreateMap<GenderListDtos, Gender>().ReverseMap();
        }
    }
}
