using ASP.Aplication.DTO.Search;
using ASP.Aplication.UseCasesAp.Commands.Contact;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.ContactValFolder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASP.Implementation.UseCasesIm.CommandsIm.ContactIm
{
    public class EfInsertContactCommand : EfUseCase, ICreateContactCommand
    {
        private readonly CreateContactValidation _validatior;
        public EfInsertContactCommand(CreateContactValidation validation,TheContext context) : base(context)
        {
            this._validatior = validation;
        }

        public int Id => 5;

        public string NameUseCase => "Create Contact";

        public string DescriptionUseCase => "Create Contact";

        public void Execute(ContactDto request)
        {
            this._validatior.ValidateAndThrow(request);
            Contact contact = new Contact
            {
                Name = request.Name,
                Subject = request.Subject,
                Email = request.Email,
                Body = request.Body
                
            };
            Context.Contacts.Add(contact);
            Context.SaveChanges();
        }
    }
}
