using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.UseCasesAp.Commands.Recipe;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Statics;
using ASP.Implementation.Validators.Recipe;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.RecipeIm
{
    public class EFInsertRecipeCommand : EfUseCase, ICreateRecipeCommand
    {
        private readonly RecipeDtoValidator _validator;
        public EFInsertRecipeCommand(TheContext context, RecipeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 20;

        public string NameUseCase => "Create recipe";

        public string DescriptionUseCase => "Create recipe";

        public void Execute(CreateRecipeDto request)
        {
            this._validator.ValidateAndThrow(request);
            string path = Picture.Upload(request.Image, "images/recipes");
            ImageFile image = new ImageFile
            {
                Path = path,
            };
            Context.ImageFiles.Add(image);
            Context.SaveChanges();
            Recipe recipe = new Recipe {
            TitleRecipe=request.TitleRecipe,
            TotalKcal=request.TotalKcal,
            Description=request.Description,
            IdImageFile=image.Id
            };
            Context.Recipes.Add(recipe);
            Context.SaveChanges();
        }
    }
}
