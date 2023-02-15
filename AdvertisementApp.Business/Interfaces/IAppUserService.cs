using AdvertisementApp.Common;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Interfaces
{
   public interface IAppUserService : IService<AppUserCreateDtos, AppUserUpdateDtos,
       AppUserListDtos, AppUser>
    {
        Task<IResponse<AppUserCreateDtos>> CreateWithRoleAsync(AppUserCreateDtos dto, int roleıd);
        Task<IResponse<AppUserListDtos>> CheckUserAsync(AppUserLoginDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByIdAsync(int userId);
    }
}
