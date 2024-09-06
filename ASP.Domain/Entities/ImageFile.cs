using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class ImageFile : Entity
    {
        public string Path { get; set; }


        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
