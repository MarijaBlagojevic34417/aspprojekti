using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class Recipe : Entity
    {
        public int IdUser { get; set; }
        public int IdImageFile { get; set; }


        public string TitleRecipe { get; set; }
        public string Description { get; set; }
        public int TotalKcal { get; set; }


        public virtual User User { get; set; }
        public virtual ImageFile ImageFiles { get; set; }

        public virtual ICollection<RecipeFood> RecipeFoods { get; set; } = new List<RecipeFood>();
        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();
        public virtual ICollection<UserRecipeReaction> UserRecipeReactions { get; set; } = new List<UserRecipeReaction>();
       
    }
}