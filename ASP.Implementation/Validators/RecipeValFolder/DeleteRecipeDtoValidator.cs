using ASP.Aplication.DTO.Recipe;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.Recipe
{
    public class DeleteRecipeDtoValidator:AbstractValidator<DeleteRecipeDto>
    {
        public DeleteRecipeDtoValidator(TheContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Recipes.Any(b => b.Id == x && b.IsActive == true)).WithMessage("Wrong id,  doesn't exist");
        }
    }
}
