using ASP.Aplication.DTO;
using ASP.Aplication.DTO.RateAp;
using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.DTO.SearchQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCasesAp.QueryAp.RecipeQ
{
    public interface IGetRecipeQuery : IQuery<PagedResponseDto<RecipeDto>, RecipeSearch>
    {
    }
}
