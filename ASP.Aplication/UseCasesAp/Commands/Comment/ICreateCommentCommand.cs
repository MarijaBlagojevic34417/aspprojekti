using ASP.Aplication.DTO.Comment;
using ASP.Aplication.UseCasesAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.Comment
{
    public interface ICreateCommentCommand:ICommand<CommentDto>
    {
    }
}
