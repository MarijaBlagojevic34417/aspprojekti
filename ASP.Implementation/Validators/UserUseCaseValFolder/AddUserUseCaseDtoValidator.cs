using ASP.Aplication.DTO.UserUseCase;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.UserUseCase
{
    public class AddUserUseCaseDtoValidator:AbstractValidator<UserUseCaseDto>
    {
        public AddUserUseCaseDtoValidator(TheContext context) {

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.IdUser).Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User doesn't exist");

            RuleFor(x => x.UseCaseIds).NotEmpty().WithMessage("Parameter is required")                                     
                                      .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");

        }
    }
    }

