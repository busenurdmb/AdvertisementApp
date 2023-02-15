﻿using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using FluentValidation;

namespace AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("Bir cv dosyası seçiniz");
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.AdvertisementUserStatusId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId ==(int)MilitaryStatusType.Tecilli).WithMessage("tecil tarihi boş bırakılamaz");
          
        }
    }
}
