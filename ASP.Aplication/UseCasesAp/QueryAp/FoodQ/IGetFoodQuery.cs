using ASP.Aplication.DTO;
using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.DTO.SearchQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCasesAp.QueryAp.FoodQ
{
    public interface IGetFoodQuery : IQuery<PagedResponseDto<FoodDto>, FoodSearch>
    {
    }
}
