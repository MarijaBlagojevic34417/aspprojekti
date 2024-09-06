using ASP.Aplication.DTO.RateAp;
using ASP.Aplication.UseCasesAp.Commands.Rate;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.RateValFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.RateIm
{
    public class EfInsertRateCommand : EfUseCase, ICreateRateCommand
    {
      private readonly RateDtoValidator _validator;
        public EfInsertRateCommand(TheContext context, RateDtoValidator validator) : base(context)
        {
            _validator=validator;
        }

        public int Id => 26;

        public string NameUseCase => "Insert rate";

        public string DescriptionUseCase => "Insert rate ef";

        public void Execute(CreateRateDto request)
        {
            Rate ratee = new Rate {
            
                NameRate= request.NameRate
                 
        };
            Context.Rates.Add(ratee);
            Context.SaveChanges();
        }
      
    }
}
