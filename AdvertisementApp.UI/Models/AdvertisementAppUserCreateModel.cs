using AdvertisementApp.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        public int AdvertisementId { get; set; }
       
        public int AppUserId { get; set; }

        public int AdvertisementUserStatusId { get; set; } = (int)AdvertisementAppUserStatusType.Başvuruldu;
        
        public int MilitaryStatusId { get; set; }
        //public SelectList MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }
    }
}
