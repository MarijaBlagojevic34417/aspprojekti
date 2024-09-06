using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.SearchQ;

namespace ASP.Aplication.UseCasesAp.QueryAp.CategoryQ
{
    public interface IGetCategoryQuery : IQuery<PagedResponseDto<CategoryDto>, CategorySearch>
    {
    }
}
