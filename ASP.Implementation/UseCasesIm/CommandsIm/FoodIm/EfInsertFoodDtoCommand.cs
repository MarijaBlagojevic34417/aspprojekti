using ASP.Domain.Entities;
using ASP.Aplication.DTO.Food;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.DataAccess;

using ASP.Implementation.Validators.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.FoodIm
{
    public class EfInsertFoodDtoCommand : EfUseCase, ICreateFoodCommand
    {

        private readonly FoodDtoValidator _validator;
        public EfInsertFoodDtoCommand(TheContext context, FoodDtoValidator validator) : base(context)
        {
            _validator = validator; 
        }

        public int Id => 11;

        public string NameUseCase => "Insert food";

        public string DescriptionUseCase => "Insert food EF";

        public void Execute(CreateFoodDto request)
        {
            _validator.Validate(request);
            Food food = new Food
            {
                NameFood= request.NameFood,
                KcalPer100gr=request.KcalPer100gr
                
            };
            Context.Foods.Add(food);
            Context.SaveChanges();
        }
    }
}
