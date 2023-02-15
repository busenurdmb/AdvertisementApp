using AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Dtos
{
   public class AdvertisementAppUserCreateDto:IDto
    {
        public int AdvertisementId { get; set; }

        public int AppUserId { get; set; }

        public int AdvertisementUserStatusId { get; set; } 

        public int MilitaryStatusId { get; set; }
        //public SelectList MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
