using ASP.Aplication.DTO.Food;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.Food;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASP.Implementation.UseCasesIm.CommandsIm.FoodIm
{
    public class EfDeleteFoodCommand : EfUseCase, IDeleteFoodCommand
    {
        private readonly DeleteFoodDtoValidator _validation;
        public EfDeleteFoodCommand(TheContext context, DeleteFoodDtoValidator validation) : base(context)
        {
            _validation = validation;
        }

        public int Id => 13;

        public string NameUseCase => "Delete food";

        public string DescriptionUseCase => "Delete food";

        public void Execute(DeleteFoodDto request)
        {
            _validation.ValidateAndThrow(request);

            Food comment = Context.Foods.FirstOrDefault(c => c.Id == Id);


            if (comment != null)
            {
                comment.IsActive = !comment.IsActive;
                Context.SaveChanges();
            }

        }
    }
}
