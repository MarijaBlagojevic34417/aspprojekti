using ASP.Aplication.DTO.Comment;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.Comment
{
    public class CommentDtoValidator:AbstractValidator<CommentDto>
    {
        public CommentDtoValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Text).NotEmpty()
                                .WithMessage("Text  is required")
                                .MinimumLength(2)
                                .WithMessage("Text must contain at least 2 characters");

            RuleFor(x => x.IdUser).NotEmpty().WithMessage("User id is required")
                 .Must(x => context.Users.Any(c => c.Id == x)).WithMessage("User does't exist");

            RuleFor(x => x.IdRecipe).NotEmpty().WithMessage("Recipe id is required")
                 .Must(x => context.Recipes.Any(c => c.Id == x)).WithMessage("Recipe does't exist");


        }

    }    
    }

