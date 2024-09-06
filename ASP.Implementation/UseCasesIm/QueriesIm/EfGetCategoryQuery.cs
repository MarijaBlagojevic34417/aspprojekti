using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.DTO;
using ASP.Aplication.UseCasesAp.QueryAp.FoodQ;
using ASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.Aplication.UseCasesAp.QueryAp.CategoryQ;
using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.SearchQ;

namespace ASP.Implementation.UseCasesIm.QueriesIm
{
    public class EfCategoryQuery : EfUseCase, IGetCategoryQuery
    {
        public EfCategoryQuery(TheContext context) : base(context)
        {
        }

        public int Id => 33;
        public string NameUseCase => "Search category";

        public string DescriptionUseCase => "Search category";

        public PagedResponseDto<CategoryDto> Execute(CategorySearch search)
        {
            var query = Context.Categories.AsQueryable();

            query = query.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.NameCategory.Contains(search.Keyword));
            }

            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            query = query.Skip(skip).Take(perPage);


            var categoriesDto = query.Select(x => new CategoryDto
            {
                NameCategory = x.NameCategory

            }).ToList();

            return new PagedResponseDto<CategoryDto>
            {
                CurrentPage = page,
                Data = categoriesDto,
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }



    }
}
