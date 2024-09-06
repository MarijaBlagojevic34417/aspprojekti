using ASP.Aplication.DTO.ReactionAp;
using ASP.Aplication.UseCasesAp.Commands.Reaction;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.ReactionValFolder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.ReactionIm
{
    public class EfDeleteReactionCommand : EfUseCase, IDeleteReactionCommand
    {
        private readonly DeleteReactionValidator _validator;
        public EfDeleteReactionCommand(TheContext context, DeleteReactionValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string NameUseCase => "Delete Reaction";

        public string DescriptionUseCase => "Delete Reaction ef";

        public void Execute(DeleteReactionDto request)
        {

            _validator.ValidateAndThrow(request);

            Reaction reaction = Context.Reactions.FirstOrDefault(r => r.Id == Id);
                
              


            if (reaction != null)
            {
                reaction.IsActive = !reaction.IsActive;
                Context.SaveChanges();
            }
        }
    }
}
