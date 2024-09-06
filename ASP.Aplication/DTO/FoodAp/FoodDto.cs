using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.Food
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string NameFood { get; set; }
        public int KcalPer100gr { get; set; } 
    }
    public class CreateFoodDto
    {
        public string NameFood { get; set; }
        public int KcalPer100gr { get; set; }
    }
    public class UpdateFoodDto
    {
        public int Id { get; set; }
        public string NameFood { get; set; }
        public int KcalPer100gr { get; set; }
    }

    public class DeleteFoodDto
    {
        public int Id { get; set; }
    }
}
