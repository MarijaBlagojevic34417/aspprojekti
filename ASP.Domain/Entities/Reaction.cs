using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class Reaction:Entity
    {
        public string NameReaction { get; set; }
    

        public IEnumerable<UserCommentReaction> UserCommentReactions { get; set; } = new List<UserCommentReaction>();
        public IEnumerable<UserRecipeReaction> UserRecipeReactions { get; set; } = new List<UserRecipeReaction>();
    }
}
