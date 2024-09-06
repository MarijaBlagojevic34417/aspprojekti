using ASP.Aplication.DTO.Comment;
using ASP.Aplication.DTO.Useri;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.CommentValFolder
{
    public class UpdateCommentDtoValidator : AbstractValidator<CommentDto>
    {
    
        public UpdateCommentDtoValidator(TheContext context)
        {
           

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdUser).NotEmpty()
                .WithMessage("User is required")
                .Must(id => context.Users.Any(u => u.Id == id))
                .WithMessage("User doesn't exist");

            RuleFor(x => x.Text).NotEmpty()
                               .WithMessage("Text is required");

            RuleFor(x => x.IdRecipe).NotEmpty()
                .WithMessage("Recipe is required")
                .Must(recipe => context.Recipes.Any(u => u.Id == recipe))
                .WithMessage("Recipe doesn't exist");

          

           




        }
    }
}

