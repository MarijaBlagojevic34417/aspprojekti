using ASP.Aplication.DTO.Useri;
using ASP.Aplication.UseCases.Commands.User;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Statics;
using ASP.Implementation.Validators.User;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASP.Implementation.UseCasesIm.CommandsIm.UsersIm
{
    public class EFUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly EditUserDtoValidator _validate;
        public EFUpdateUserCommand(TheContext context, EditUserDtoValidator validate) : base(context)
        {
            _validate = validate;
        }

        public int Id => 3;

        public string Name => "Update user";

        public string NameUseCase => "Update user";

        public string DescriptionUseCase => "Update user";

        

        public void Execute(UpdateUserDto request)
        {
            _validate.ValidateAndThrow(request);
            User userToEdit = Context.Users.FirstOrDefault(x => x.Id == request.Id);
            if (userToEdit != null)
            {
                string picture_path = Picture.Upload(request.Picture, "images/users");
                ImageFile image = new ImageFile
                {
                    Path = picture_path,
                };
                Context.ImageFiles.Add(image);
                Context.SaveChanges();
                userToEdit.FirstName = request.FirstName;
                userToEdit.LastName = request.LastName;
                userToEdit.Email = request.Email;
                userToEdit.Username = request.Username;
                userToEdit.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                userToEdit.IdImageFile = image.Id;
                Context.SaveChanges();
            }
        }
    }
}



   