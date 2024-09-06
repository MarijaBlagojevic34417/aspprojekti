using ASP.Aplication.DTO.RateAp;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.RateValFolder
{
    public class UpdateRateValidator:AbstractValidator<UpdateRateDto>
    {

        public  UpdateRateValidator(TheContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.NameRate).GreaterThan(0).WithMessage("Kcal must be grather then 0");
            RuleFor(x => x.NameRate).LessThan(6).WithMessage("Kcal must be less then 6");


        }

        
    }
}