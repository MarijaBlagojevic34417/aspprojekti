using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class Rate:Entity
    {
        public int IdRecipe { get; set; }
        public int IdUser { get; set; }
        public int NameRate { get; set; }

        public User User { get; set; }
        public Recipe Recipe { get; set; }

    }
}
