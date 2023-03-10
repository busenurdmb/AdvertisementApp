using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities
{
   public class Advertisement:BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatDate { get; set; }
        public List<AdvertisementAppUser> advertisementAppUsers { get; set; }
    }
}
