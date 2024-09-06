using ASP.Aplication.DTO.Comment;
using ASP.Aplication.UseCases.Commands.Comment;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.Comment;
using ASP.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.CommentsIm
{
    public class EFInsertCommentCommand : EfUseCase, ICreateCommentCommand
    {
        private readonly CommentDtoValidator _validator;
        public EFInsertCommentCommand(TheContext context,CommentDtoValidator validator) : base(context)
        {
            this._validator = validator;
        }

        public int Id => 17;

        public string NameUseCase => "Create Comment";

        public string DescriptionUseCase => "Create Comment Ef";

        
       
        public void Execute(CommentDto request)
        {
            _validator.Validate(request);
            Comment commentar = new Comment
            {
                Text = request.Text,
                IdRecipe=request.IdRecipe,
                IdUser=request.IdUser,
                IdParentComment=request.IdParentComment,
               
            };
            Context.Comments.Add(commentar);
            Context.SaveChanges();
        }

        
    }
}
