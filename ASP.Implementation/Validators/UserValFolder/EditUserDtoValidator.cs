using ASP.Aplication.DTO.Useri;
using ASP.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.User
{
    public class EditUserDtoValidator:AbstractValidator<UpdateUserDto>
    {
        private readonly TheContext _context;

        public EditUserDtoValidator(TheContext context) {
            _context = context;
           

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User doesn't exist");

            RuleFor(x => x.Email).NotEmpty()
                               .WithMessage("Email is required")
                               .EmailAddress()
                               .WithMessage("Please enter email format");

            RuleFor(x => x.FirstName).NotEmpty()
                                   .WithMessage("First name is required")
                                   .MinimumLength(3)
                                   .WithMessage("Name must have at least 3 characters");

            RuleFor(x => x.LastName).NotEmpty()
                                   .WithMessage("Last name is required")
                                   .MinimumLength(3)
                                   .WithMessage("Name must have at least 3 characters");

            RuleFor(x => x.Username).NotEmpty()
                                 .WithMessage("Username is required")
                                 .MinimumLength(3)
                                 .WithMessage("Minimun username length is 3 characters")
                                .Must((dto, username) => !IsUsernameInUse(dto.Id, username))
                                 .WithMessage("Username is already in use");

           


            RuleFor(x => x.Password).NotEmpty()
                                  .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$")
                                  .WithMessage("Password must be 8-20 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.");

        }
        private bool IsUsernameInUse(int id, string username)
        {
            return _context.Users.Any(u => u.Username == username && u.Id != id);
        }
    }
    }

