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
    public class UpdateReactionValidator:AbstractValidator<UpdateReactionDto>
    {
        public UpdateReactionValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;

           

            RuleFor(x => x.NameReaction).NotEmpty()
                              .WithMessage("Name of food is required")
                              .MinimumLength(2)
                              .WithMessage("Minimum length is 2 characters");



        }
    }
}
