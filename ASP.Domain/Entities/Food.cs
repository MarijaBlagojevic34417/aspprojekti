using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class Food : Entity
    {
        public string NameFood { get; set; }
        public int KcalPer100gr { get; set; }

        public virtual ICollection<RecipeFood> RecipeFoods { get; set; } = new List<RecipeFood>();

    }
}
