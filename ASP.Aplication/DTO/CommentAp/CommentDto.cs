using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.DTO.Useri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        //
        public int IdRecipe { get; set; }
        public int IdUser { get; set; }
        public int IdParentComment { get; set; }
    }
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public int IdRecipe {  get; set; }
        


    }
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class DeleteCommentDto
    {
        public int Id { get; set; }
    }
}
