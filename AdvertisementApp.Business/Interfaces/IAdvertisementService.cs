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
   public interface IAdvertisementService : IService<AdvertisementCreateDtos, AdvertisementUpdateDtos,
       AdvertisementListDtos, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDtos>>> GetActivesAync();
    }
}
