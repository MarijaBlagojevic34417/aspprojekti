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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ASP.Implementation.UseCasesIm.CommandsIm.ReactionIm
{
    public class EfUpdateReactionCommand : EfUseCase, IUpdateReactionCommand
    {
        private readonly UpdateReactionValidator _validator;
        public EfUpdateReactionCommand(TheContext context, UpdateReactionValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string NameUseCase => "Update reaction";

        public string DescriptionUseCase => "Update reaction ef";

        public void Execute(UpdateReactionDto request)
        {
            _validator.ValidateAndThrow(request);

            Reaction ToEdit = Context.Reactions.FirstOrDefault(x => x.Id == request.Id);
            ToEdit.NameReaction = request.NameReaction;
            Context.SaveChanges();
        }
    }
}
