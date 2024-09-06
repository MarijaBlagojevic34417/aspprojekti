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
    public class EfUpdateRateCommand : EfUseCase,IUpdateRateCommand
    {
        private readonly UpdateRateValidator _validation;
        public EfUpdateRateCommand(TheContext context, UpdateRateValidator validation) : base(context)
        {
            _validation=validation;
        }

        public int Id => 27;

        public string NameUseCase =>"Update rate";

        public string DescriptionUseCase => "Update rate ef";

        public void Execute(UpdateRateDto request)
        {
            _validation.ValidateAndThrow(request);

            Rate ToEdit = Context.Rates.FirstOrDefault(x => x.Id == request.Id);
            ToEdit.NameRate = request.NameRate;
            Context.SaveChanges();
        }
    }
}
