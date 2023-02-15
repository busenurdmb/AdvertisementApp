using AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Dtos
{
  public  class GenderListDtos:IDto
    {
        public int Id { get; set; }
        public String Definiiton { get; set; }
    }
}
