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
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator(TheContext context)
        {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.NameCategory).NotEmpty()
                                .WithMessage("Text  is required")
                                .MinimumLength(2)
                                .WithMessage("Text must contain at least 2 characters");



        }

    }

}
