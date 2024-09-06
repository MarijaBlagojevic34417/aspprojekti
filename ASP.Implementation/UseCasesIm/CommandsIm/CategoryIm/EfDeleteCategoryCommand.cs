using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.UseCasesAp.Commands.Category;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.CategoryValFolder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ASP.Implementation.UseCasesIm.CommandsIm.CategoryIm
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {

        private readonly DeleteCategoryValidator _validator;
        public EfDeleteCategoryCommand(TheContext context, DeleteCategoryValidator validator) : base(context)
        {
        }

        public int Id => 10;

        public string NameUseCase => "Delete category";

        public string DescriptionUseCase => "Delete category EF";

        public void Execute(DeleteCategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            Category cat = Context.Categories.FirstOrDefault(c => c.Id == Id);


            if (cat != null)
            {
                cat.IsActive = !cat.IsActive;
                Context.SaveChanges();
            }

        }
    }
}
