using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.UseCases.Commands.Recipe;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.Recipe;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASP.Implementation.UseCasesIm.CommandsIm.RecipeIm
{
    public class EfDeleteRecipeCommand : EfUseCase, IDeleteRecipeCommand
    {
        private readonly DeleteRecipeDtoValidator _validator;
        public EfDeleteRecipeCommand(TheContext context, DeleteRecipeDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string NameUseCase =>"Delete Recipe";

        public string DescriptionUseCase => "Delete Recipe";

        public void Execute(DeleteRecipeDto request)
        {
            _validator.ValidateAndThrow(request);

            Comment comment = Context.Comments.FirstOrDefault(c => c.Id == Id);


            if (comment != null)
            {
                comment.IsActive = !comment.IsActive;
                Context.SaveChanges();
            }

        }
    }
}
