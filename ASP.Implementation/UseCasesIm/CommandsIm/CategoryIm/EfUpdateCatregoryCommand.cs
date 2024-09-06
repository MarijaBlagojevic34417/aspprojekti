using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.Food;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCasesAp.Commands.Category;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.CategoryValFolder;
using ASP.Implementation.Validators.FoodValFolder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.CategoryIm
{
    public class EfUpdateCatregoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        private readonly UpdateCategoryValidator _validation;

        public EfUpdateCatregoryCommand(TheContext context, UpdateCategoryValidator validation) : base(context)
        {
            _validation = validation;
        }

        public int Id => 9;

        public string NameUseCase => "Update category";

        public string DescriptionUseCase => "Update category EF";

        public void Execute(UpdateCategoryDto request)
        {

            _validation.ValidateAndThrow(request);

            Category ToEdit = Context.Categories.FirstOrDefault(x => x.Id == request.Id);
            ToEdit.NameCategory = request.NameCategory;
            Context.SaveChanges();
        }
    }
   
}
