using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
   
        public class RecipeCategory
        {
           
            public int IdRecipe { get; set; }
            public int IdCategory { get; set; }

            public Recipe Recipe { get; set; }
            public Category Category { get; set; }

            
        }
    }

