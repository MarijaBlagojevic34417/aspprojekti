using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class RecipeFood
    {
     
        public int IdRecipe { get; set; }
        public int IdFood { get; set; }
        public int Gram { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Food Food { get; set; }
    }
}
