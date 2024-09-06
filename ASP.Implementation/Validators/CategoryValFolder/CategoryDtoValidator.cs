using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.Comment;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.CategoryValFolder
{
    public class CategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoryDtoValidator(TheContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.NameCategory).NotEmpty()
                                .WithMessage("Text  is required")
                                .MinimumLength(3)
                                .WithMessage("Text must contain at least 3 characters");

           


        }

    }    
    
}
