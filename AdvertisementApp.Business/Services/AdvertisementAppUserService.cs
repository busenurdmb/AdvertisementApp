using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
   public class AdvertisementAppUserService: IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _validator;
        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> validator, IMapper mapper)
        {
            _uow = uow;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _validator.Validate(dto);
            
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x
                    => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
           
                if (control == null)
                {
                    var entity = _mapper.Map<AdvertisementAppUser>(dto);
                await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(entity);
                await _uow.SaveChanges();
                return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new List<CustomValidationError> { new CustomValidationError { ErrorMessage = "Daha önce başvurulan ilana başvuralamaz", ProperTyName = "" } };

                return new Response<AdvertisementAppUserCreateDto>(dto, errors);
            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());

        }
        public async Task<List<AdvertisemnetAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
            var list= await  query.Include(x => x.advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.Appuser).ThenInclude(x=>x.Gender).Where(x => x.AdvertisementUserStatusId == (int)type).ToListAsync();
            var dto = _mapper.Map<List<AdvertisemnetAppUserListDto>>(list);
            return dto;
        }
        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var unchanged =await _uow.GetRepository<AdvertisementAppUser>().FindAsync(advertisementAppUserId);
            //var changed = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x=>x.Id==advertisementAppUserId);
            //changed.Id = advertisementAppUserId;
            //changed.AdvertisementUserStatusId = (int)type;
            //_uow.GetRepository<AdvertisementAppUser>().Update(changed, unchanged);
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
           var entity= await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementUserStatusId =(int)type;
            await _uow.SaveChanges();
        }
    }
}
