using AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Dtos
{
   public class GenderUpdateDtos:IUpdateDto
    {
        public int Id { get; set; }
        public String Definiiton { get; set; }
    }
}
