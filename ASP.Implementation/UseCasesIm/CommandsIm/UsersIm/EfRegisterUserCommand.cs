using ASP.Aplication.DTO.Useri;
using ASP.Aplication.UseCases.Commands.EmailSend;
using ASP.Aplication.UseCases.Commands.User;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Statics;
using ASP.Implementation.Validators.User;
using FluentValidation;
using Google.Apis.Gmail.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASP.Implementation.UseCasesIm.CommandsIm.UsersIm
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private RegisterUserDtoValidator _validator;
        private readonly IEmailService emailService;

      

        public int Id => 1;

        public string NameUseCase =>"User registration";

        public string DescriptionUseCase => "User registration EF";


        public EfRegisterUserCommand(TheContext context, RegisterUserDtoValidator validator, IEmailService ser) : base(context)
        {
            _validator = validator;
            emailService = ser;
        }

        public void Execute(RegisterUserDto request)
        {

            _validator.ValidateAndThrow(request);

            var allowedUseCasesForNewUser = new List<int> { 3, 17, 18, 19 };
            var useCasesForNewUser = new List<UserUseCase>();
            string picture_path = Picture.Upload(request.Picture, "images/users");
            foreach (var i in allowedUseCasesForNewUser)
            {
                useCasesForNewUser.Add(new UserUseCase { IdUseCase = i });
            };
            ImageFile image = new ImageFile
            {
                Path = picture_path,


            };
            Context.ImageFiles.Add(image);
            Context.SaveChanges();
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                IdImageFile = image.Id,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),

                UserUseCases = useCasesForNewUser
            };
            Context.Users.Add(user);
            Context.SaveChanges();
            emailService.SendEmail(request.Email, "Registration", "<h1>Successfull registration!</h1>");
             //emailService.SendEmail(request.Email,"Registration", "Successfull registration");


        }
    }
}
