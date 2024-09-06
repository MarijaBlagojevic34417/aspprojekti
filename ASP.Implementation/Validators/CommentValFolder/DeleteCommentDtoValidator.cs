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
    public class DeleteCommentDtoValidator:AbstractValidator<DeleteCommentDto>
    {

        public DeleteCommentDtoValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Comments.Any(b => b.Id == x && b.IsActive == true)).WithMessage("Wrong id, comment doesn't exist");


        }
    }
}
