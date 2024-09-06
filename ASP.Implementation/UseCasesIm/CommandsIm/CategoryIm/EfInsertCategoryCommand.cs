using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.UseCasesAp.Commands.Category;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.CategoryValFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.CategoryIm
{
    public class EfInsertCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private readonly CategoryDtoValidator _validator;
        public EfInsertCategoryCommand(TheContext context, CategoryDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string NameUseCase => "Create category";

        public string DescriptionUseCase => "Create category";

        public void Execute(CreateCategoryDto request)
        {
            _validator.Validate(request);
            Category food = new Category
            {
                NameCategory = request.NameCategory

            };
            Context.Categories.Add(food);
            Context.SaveChanges();
        }
    }
}
