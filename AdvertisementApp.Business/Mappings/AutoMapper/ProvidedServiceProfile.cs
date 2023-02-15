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
    public class ProvidedServiceProfile:Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDtos, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceListDtos, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDtos, ProvidedServices>().ReverseMap();
        
        }
    }
}
