using ASP.Aplication.DTO.Useri;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.Recipe
{

    public class RecipeDto
    {
        public int Id { get; set; }
        public string TitleRecipe { get; set; }
        public string Description { get; set; }
        public int TotalKcal { get; set; }
        public int IdUser { get; set; }
        public IFormFile Image { get; set; }

    }
    public class CreateRecipeDto
    {
        public string TitleRecipe { get; set; }
        public string Description { get; set; }
        public int TotalKcal { get; set; }
        public int IdUser { get; set; }
        public IFormFile Image { get; set; }

    }
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string TitleRecipe { get; set; }
        public string Description { get; set; }
        public int TotalKcal { get; set; }
        public IFormFile Image { get; set; }


    }

    public class DeleteRecipeDto
    {
        public int Id { get; set; }
    }




}
