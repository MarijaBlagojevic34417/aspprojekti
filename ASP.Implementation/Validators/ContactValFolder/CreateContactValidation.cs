using ASP.Aplication.DTO.Search;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.ContactValFolder
{
    public class CreateContactValidation:AbstractValidator<ContactDto>
    {
        public CreateContactValidation()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Name can not be empty")
                                .MinimumLength(3)
                                .WithMessage("Name must has minimum 3 characters");
            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("Email can not be empty")
              .EmailAddress()
              .WithMessage("Email can be in email format");

            RuleFor(x => x.Subject).NotEmpty()
                               .WithMessage("Subject can not be empty")
                               .MinimumLength(3)
                               .WithMessage("Subject must has minimum 3 characters");

            RuleFor(x => x.Body).NotEmpty()
                               .WithMessage("Body can not be empty")
                               .MinimumLength(20)
                               .WithMessage("Subject must has minimum 20 characters");
        }
    }
}
