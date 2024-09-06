using ASP.Aplication.DTO.ReactionAp;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.ReactionValFolder
{
    public class DeleteReactionValidator:AbstractValidator<DeleteReactionDto>
    {

        public DeleteReactionValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Reactions.Any(b => b.Id == x && b.IsActive == true)).WithMessage("Wrong id, reaction doesn't exist");

        }
    }
}
