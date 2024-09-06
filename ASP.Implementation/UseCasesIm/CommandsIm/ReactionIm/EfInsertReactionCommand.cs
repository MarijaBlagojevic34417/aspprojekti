using ASP.Aplication.DTO.ReactionAp;
using ASP.Aplication.UseCasesAp.Commands.Reaction;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.ReactionValFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.ReactionIm
{
    public class EfInsertReactionCommand : EfUseCase, ICreateReactionCommand
    {
        private readonly ReactionDtoValidator _validator;
        public EfInsertReactionCommand(TheContext context, ReactionDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string NameUseCase => "Create reaction";

        public string DescriptionUseCase => "Create reaction ef";

        public void Execute(CreateReactionDto request)
        {
            _validator.Validate(request);
            Reaction reac = new Reaction
            {
                NameReaction = request.NameReaction
               

            };
            Context.Reactions.Add(reac);
            Context.SaveChanges();
        }
    }
}
