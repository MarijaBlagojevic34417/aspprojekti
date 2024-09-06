using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.UseCases.Commands.Recipe;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Statics;
using ASP.Implementation.Validators.RecipeValFolder;
using Azure.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.RecipeIm
{
    public class EfUpdateRecipeCommand : EfUseCase, IUpdateRecipeCommand
    {
        private readonly UpdateRecipeDtoValidator _validator;
        public EfUpdateRecipeCommand(TheContext context, UpdateRecipeDtoValidator validator) : base(context)
        {
            _validator=validator;
        }

        public int Id => 21;

        public string NameUseCase => "Update recipe";

        public string DescriptionUseCase => "Update recipe ef";

        public void Execute(UpdateRecipeDto request)
        {
            this._validator.ValidateAndThrow(request);
            
            Recipe ToEdit=Context.Recipes.FirstOrDefault(x => x.Id == request.Id);
            
            if(ToEdit != null)
            {
                string picture_path = Picture.Upload(request.Image, "images/recipes");
                ImageFile image = new ImageFile
                {
                    Path = picture_path,
                };
                Context.ImageFiles.Add(image);
                Context.SaveChanges();
                ToEdit.TitleRecipe = request.TitleRecipe;
                ToEdit.TotalKcal = request.TotalKcal;
                ToEdit.Description = request.Description;
                ToEdit.IdImageFile = image.Id;
                Context.Recipes.Add(ToEdit);
                Context.SaveChanges();
            }
            
        }
    }
}


