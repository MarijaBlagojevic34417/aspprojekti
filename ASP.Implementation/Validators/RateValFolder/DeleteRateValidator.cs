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
    public class DeleteRateValidator:AbstractValidator<DeleteRateDto>
    {

        public DeleteRateValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Reactions.Any(b => b.Id == x && b.IsActive == true)).WithMessage("Wrong id, rate doesn't exist");


        }


    }
}
