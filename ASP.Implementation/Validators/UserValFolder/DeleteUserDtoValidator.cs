using ASP.Aplication.DTO.Useri;
using ASP.DataAccess;
using ASP.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.Validators.User
{
    public class DeleteUserDtoValidator:AbstractValidator<DeleteUserDto>
    {
        public DeleteUserDtoValidator(TheContext context) {


            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).Must(x => context.Users.Any(b => b.Id == x && b.IsActive == true)).WithMessage("Wrong id,  doesn't exist");
        }
    }
    }

