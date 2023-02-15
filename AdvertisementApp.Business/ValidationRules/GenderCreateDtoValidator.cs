﻿using AdvertisementApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules
{
    public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDtos>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definiiton).NotEmpty();
        }
    }
}
