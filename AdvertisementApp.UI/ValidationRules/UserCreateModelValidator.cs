using AdvertisementApp.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
       // [Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode=CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password not match");
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Username).MinimumLength(3);
            RuleFor(x => new { 
            x.Username,
            x.Firstname
            }).Must(x=>  CanNotfirstname(x.Username,x.Firstname)).WithMessage("user name contains firstname!").When(x=>x.Username!=null && x.Firstname!=null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur");
           
        }

        private bool CanNotfirstname(string username,string firstname)
        {
            
            return !username.Contains(firstname);
            
        }
    }
}
