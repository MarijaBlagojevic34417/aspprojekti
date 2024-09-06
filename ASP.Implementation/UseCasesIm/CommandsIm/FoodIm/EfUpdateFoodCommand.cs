using ASP.Aplication.DTO.Food;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.FoodValFolder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.FoodIm
{
    public class EfUpdateFoodCommand : EfUseCase, IUpdateFoodCommand
    {
        private readonly UpdateFoodDtoValidator _validation;

        public EfUpdateFoodCommand(TheContext context, UpdateFoodDtoValidator validation) : base(context)
        {
            _validation= validation;
        }

        public int Id => 12;

        public string NameUseCase => "Update food";

        public string DescriptionUseCase => "Update food EF";

        public void Execute(UpdateFoodDto request)
        {

            _validation.ValidateAndThrow(request);

            Food ToEdit = Context.Foods.FirstOrDefault(x => x.Id == request.Id);
            ToEdit.NameFood = request.NameFood;
            ToEdit.KcalPer100gr= request.KcalPer100gr;
            Context.SaveChanges();
        }
    }
}
