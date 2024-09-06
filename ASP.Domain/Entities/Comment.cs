using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class Comment : Entity
    {
        public int IdRecipe { get; set; }
        public int IdUser { get; set; }
        public int? IdParentComment { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Comment> ChildrenComments { get; set; } = new List<Comment>();
        public virtual ICollection<UserCommentReaction> UserCommentReactions { get; set; } = new List<UserCommentReaction>();
        public virtual Comment ParentComment { get; set; }
        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }


    }
}
