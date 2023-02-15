
using AdvertisementApp.Business.Extensions;
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
    public class AppUserService : Service<AppUserCreateDtos, AppUserUpdateDtos,
        AppUserListDtos, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDtos> _createdtovalidator;
        private readonly IValidator<AppUserLoginDto> _logindtovalidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDtos> createdtovalidator, IValidator<AppUserUpdateDtos> updatevalidator, IUow uow, IValidator<AppUserLoginDto> logindtovalidator) : base(mapper, createdtovalidator, updatevalidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createdtovalidator = createdtovalidator;
            _logindtovalidator = logindtovalidator;
        }
        public async Task<IResponse<AppUserCreateDtos>> CreateWithRoleAsync(AppUserCreateDtos dto, int roleıd)
        {
            var result = _createdtovalidator.Validate(dto);
            if (result.IsValid)
            {

                var user = _mapper.Map<AppUser>(dto);

                //1.YOL

                //user.AppUserRoles = new List<AppUserRole>();
                //user.AppUserRoles.Add(new AppUserRole
                //{
                //    User = user,
                //    AppRoleId = roleıd
                //});
                //await _uow.GetRepository<AppUser>().CreateAsync(user);

                //2.YOL

                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    User = user,
                    AppRoleId = roleıd
                });

                await _uow.SaveChanges();
                return new Response<AppUserCreateDtos>(ResponseType.Success, dto);
                //await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole 
                //{ 
                //AppRoleId=roleıd,
                //AppUserId=AppUser.
                //});

            }
            return new Response<AppUserCreateDtos>(dto, result.ConvertToCustomValidationError());
        }
        public async Task<IResponse<AppUserListDtos>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validaitonresult = _logindtovalidator.Validate(dto);
            if (validaitonresult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDtos>(user);
                    return new Response<AppUserListDtos>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDtos>(ResponseType.NotFound, "kullanıcı adı veya şifre hatalı");
            }
            return new Response<AppUserListDtos>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }
        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByIdAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "ilgili rol bulunamadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }
}
