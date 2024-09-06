using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class UserRecipeReaction
    {
      
        public int IdUser { get; set; }
        public int IdRecipe { get; set; }
        public int IdReaction { get; set; }

        public User User { get; set; }
        public Recipe Recipe{ get; set; }
        public Reaction Reaction { get; set; }
    }
}
