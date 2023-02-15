using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entities
{
   public class AdvertisementAppUser:BaseEntity
    {
        public int AdvertisementId { get; set; }
        public Advertisement advertisement  { get; set; }
        public int AppUserId { get; set; }
        public AppUser Appuser { get; set; }
        public int AdvertisementUserStatusId { get; set; }
        public AdvertisementAppUserStatus AdvertisementAppUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public String CvPath { get; set; }

    }
}
