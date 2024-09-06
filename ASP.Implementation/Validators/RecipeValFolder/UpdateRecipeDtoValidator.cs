using ASP.Aplication.DTO.Recipe;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.RecipeValFolder
{
    public class UpdateRecipeDtoValidator : AbstractValidator<UpdateRecipeDto>
    {
        public UpdateRecipeDtoValidator(TheContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;



            RuleFor(x => x.TitleRecipe).NotEmpty()
                              .WithMessage("TitleRecipe of food is required")
                              .MinimumLength(5)
                              .WithMessage("Minimum length is 5 characters")
                              .Must((dto, title) => !context.Recipes.Any(r => r.TitleRecipe == title))
                              .WithMessage("You have already that recipe");
            RuleFor(x => x.Description).NotEmpty()
                             .WithMessage("Description of food is required")
                             .MinimumLength(20)
                             .WithMessage("Minimum length is 20 characters");

            RuleFor(x => x.TotalKcal).GreaterThan(10).WithMessage("It has to be minimum 10 kcal");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image id is required");
        }
    }
}
