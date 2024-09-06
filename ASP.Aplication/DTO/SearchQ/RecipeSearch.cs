using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.SearchQ
{


    public class RecipeSearch : PagedSearch
    {
        public string? TitleRecipe { get; set; }
        public string? Description { get; set; }

    }
} 

