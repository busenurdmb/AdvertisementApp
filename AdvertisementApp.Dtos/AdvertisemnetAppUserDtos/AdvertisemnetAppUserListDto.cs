using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Dtos
{
   public class AdvertisemnetAppUserListDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDtos advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUserListDtos Appuser { get; set; }
        public int AdvertisementUserStatusId { get; set; }
        public AdvertisementAppUserStatusLİstDtos AdvertisementAppUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public String CvPath { get; set; }
    }
}
