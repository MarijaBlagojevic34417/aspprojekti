using ASP.Aplication.DTO.Comment;
using ASP.Aplication.UseCases.Commands.Comment;
using ASP.DataAccess;
using ASP.Domain.Entities;
using ASP.Implementation.Validators.Comment;
using ASP.Implementation.Validators.CommentValFolder;
using ASP.Implementation.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.CommandsIm.CommentsIm
{
    public class EFEditCommentCommand : EfUseCase, IUpdateCommentCommand
    {


        

        private readonly UpdateCommentDtoValidator _validator;

        public EFEditCommentCommand(TheContext context, UpdateCommentDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string NameUseCase => "Update comment";

        public string DescriptionUseCase => "Update comment Ef";

        public void Execute(CommentDto request)
        {
           

            _validator.ValidateAndThrow(request);

            Comment ToEdit = Context.Comments.FirstOrDefault(x=>x.Id==request.Id);
            if(ToEdit != null)
            {
                ToEdit.Text = request.Text;
                ToEdit.IdUser = request.IdUser;
                ToEdit.IdParentComment = request.IdParentComment;
                ToEdit.Text = request.Text;
                Context.Comments.Add(ToEdit);
                Context.SaveChanges();
            }
           
           
        }
    }
}
