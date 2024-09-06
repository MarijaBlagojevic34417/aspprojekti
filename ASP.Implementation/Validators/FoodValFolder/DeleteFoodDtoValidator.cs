using ASP.Aplication.DTO.Food;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.Food
{
    public class DeleteFoodDtoValidator:AbstractValidator<DeleteFoodDto>
    {
        public DeleteFoodDtoValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Foods.Any(b => b.Id == x && b.IsActive == true)).WithMessage("Wrong id, food doesn't exist");

        }






        
    }
}
