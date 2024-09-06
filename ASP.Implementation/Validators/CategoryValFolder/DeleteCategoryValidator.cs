using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.Food;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.CategoryValFolder
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryDto>
    {
        public DeleteCategoryValidator(TheContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Categories.Any(b => b.Id == x && b.IsActive==true)).WithMessage("Wrong id, category doesn't exist");

        }







    }
   
}
