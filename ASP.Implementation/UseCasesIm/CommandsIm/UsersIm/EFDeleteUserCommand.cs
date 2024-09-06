using ASP.Aplication.DTO.Useri;
using ASP.Aplication.UseCases.Commands.User;
using ASP.Aplication.UseCasesAp;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.User;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.UsersIm
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private readonly DeleteUserDtoValidator _validator;
        public EfDeleteUserCommand(TheContext context, DeleteUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }






        public int Id => 4;

        

        public string NameUseCase => "Delete User";

        public string DescriptionUseCase => "Delete User";

        public void Execute(DeleteUserDto data)
        {
            _validator.ValidateAndThrow(data);
            User user = Context.Users.FirstOrDefault(x => x.Id == data.Id);
            if (user != null)
            {
                user.IsActive = !user.IsActive;
                Context.SaveChanges();
            }
        }

        
    }
}
