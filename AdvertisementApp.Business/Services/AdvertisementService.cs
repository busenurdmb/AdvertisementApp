using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
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
    public class AdvertisementService : Service<AdvertisementCreateDtos, AdvertisementUpdateDtos, AdvertisementListDtos, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper,IValidator<AdvertisementCreateDtos> creatdtovalidator,IValidator<AdvertisementUpdateDtos> updatedtovalidator,IUow uow):base(mapper,creatdtovalidator,updatedtovalidator,uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDtos>>> GetActivesAync()
        {
           var data= await _uow.GetRepository<Advertisement>().GetAllAsync(x=>x.Status,x=>x.CreatDate, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDtos>>(data);
            return new Response<List<AdvertisementListDtos>>(ResponseType.Success,dto);
        }
    }
}
