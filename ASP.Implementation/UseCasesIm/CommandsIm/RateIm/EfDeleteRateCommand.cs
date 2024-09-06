using ASP.Aplication.DTO.RateAp;
using ASP.Aplication.UseCasesAp.Commands.Rate;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.RateValFolder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ASP.Implementation.UseCasesIm.CommandsIm.RateIm
{
    public class EfDeleteRateCommand : EfUseCase, IDeleteRateCommand
    {
        private readonly DeleteRateValidator _validator;
        public EfDeleteRateCommand(TheContext context, DeleteRateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string NameUseCase => "Delete rate";

        public string DescriptionUseCase => "Delete rate ef";

        public void Execute(DeleteRateDto request)
        {
            _validator.ValidateAndThrow(request);

            Rate rate = Context.Rates.FirstOrDefault(c => c.Id == request.Id);


            if (rate != null)
            {
                rate.IsActive = !rate.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
