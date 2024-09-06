using ASP.Aplication.DTO.Comment;
using ASP.Aplication.DTO.Useri;
using ASP.Aplication.UseCases.Commands.Comment;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.Comment;
using ASP.Implementation.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.CommentsIm
{
    public class EFDeleteCommentDtoCommand : EfUseCase, IDeleteCommentCommand
    {
        private readonly DeleteCommentDtoValidator _validator;

        public EFDeleteCommentDtoCommand(DeleteCommentDtoValidator validations,TheContext context) : base(context)
        {
            _validator = validations;
        }

        public int Id => 19;

        public string Name => "Delete Comment";

        public string NameUseCase => "Delete Comment EF";

        public string DescriptionUseCase => "Delete Comment EF";

        public void Execute(DeleteCommentDto data)
        {
            _validator.ValidateAndThrow(data);

            Comment comment = Context.Comments.FirstOrDefault(c => c.Id == Id); 

                
            if (comment != null)
            {
                comment.IsActive = !comment.IsActive;
                Context.SaveChanges();
            }
    

    
}
    } }
