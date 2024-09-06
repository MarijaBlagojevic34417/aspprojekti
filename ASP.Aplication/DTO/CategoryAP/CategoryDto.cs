using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.CategoryAP
{
    public class CategoryDto
    {
        public int Id { get; set; } 
        public string  NameCategory { get; set; } 
    }
    public class CreateCategoryDto
    {
       
        public string NameCategory { get; set; }
    }

    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
    }


    public class DeleteCategoryDto
    {
        public int Id { get; set; }
       
    }
}
