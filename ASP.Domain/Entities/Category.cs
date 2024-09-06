﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class Category:Entity
    {
        public string NameCategory { get; set; }


        public virtual ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
    }
}
