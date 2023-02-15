using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
  public  class ProvidedServiceService: Service<ProvidedServiceCreateDtos, ProvidedServiceUpdateDtos,
       ProvidedServiceListDtos, ProvidedServices>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper,IValidator<ProvidedServiceCreateDtos> createdtovalidator,IValidator<ProvidedServiceUpdateDtos> updatedtovalidator, IUow uow) :base(mapper,createdtovalidator,updatedtovalidator,uow)
        {

        }
    }
}
