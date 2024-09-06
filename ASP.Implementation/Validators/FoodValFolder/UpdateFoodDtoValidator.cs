using ASP.Aplication.DTO.Food;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.FoodValFolder
{
    public class UpdateFoodDtoValidator : AbstractValidator<UpdateFoodDto>
    {
        public UpdateFoodDtoValidator(TheContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.KcalPer100gr).GreaterThan(4).WithMessage("Kcal must be grather then 4");

            RuleFor(x => x.NameFood).NotEmpty()
                              .WithMessage("Name of food is required")
                              .MinimumLength(2)
                              .WithMessage("Minimum length is 2 characters")
                              .Must((dto, name) => !context.Foods.Any(y => y.NameFood == name))
                              .WithMessage("You have already that food");

        }
    }
}
