using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class User : Entity
    {
        public int? IdImageFile { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }


        public virtual ImageFile ImageFiles { get; set; }

        public ICollection<UserCommentReaction> UserCommentReactions { get; set; } = new List<UserCommentReaction>();
        public ICollection<UserRecipeReaction> UserRecipeReaction { get; set; } = new List<UserRecipeReaction>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserUseCase> UserUseCases { get; set; } = new List<UserUseCase>();
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();


    }
}
