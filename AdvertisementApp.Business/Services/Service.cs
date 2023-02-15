using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.Interfaces;
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
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
     where CreateDto : class, IDto, new()
         where UpdateDto : class, IUpdateDto, new()
         where ListDto : class, IDto, new()
         where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createdtovalidator;
        private readonly IValidator<UpdateDto> _updatevalidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createdtovalidator, IValidator<UpdateDto> updatevalidator, IUow uow)
        {
            _mapper = mapper;
            _createdtovalidator = createdtovalidator;
            _updatevalidator = updatevalidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto Dto)
        {
            var result = _createdtovalidator.Validate(Dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(Dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChanges();
                return new Response<CreateDto>(ResponseType.Success, Dto);
            }
            return new Response<CreateDto>(Dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<IDto>(ResponseType.NotFound, $"{id} idsine sahip data bulunmadı");
            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);
            if (data == null)
                return new Response(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");
            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChanges();
            return new Response(ResponseType.Success);

        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto Dto)
        {
            var result = _updatevalidator.Validate(Dto);
            if (result.IsValid)
            {
                var unchangedData = await _uow.GetRepository<T>().FindAsync(Dto.Id);
                if (unchangedData == null)
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{Dto.Id} idsine sahip  data bulunamadı");
                var entity = _mapper.Map<T>(Dto);
                _uow.GetRepository<T>().Update(entity, unchangedData);
                await _uow.SaveChanges();
                 return new Response<UpdateDto>(ResponseType.Success, Dto);
            }
            return new Response<UpdateDto>(Dto, result.ConvertToCustomValidationError());
        }
    }
}
