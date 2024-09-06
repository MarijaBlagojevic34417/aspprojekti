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


using ASP.Aplication.DTO.RateAp;
using ASP.Aplication.DTO.SearchQ;
using ASP.Aplication.UseCasesAp.QueryAp.RecipeQ;
using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.UseCasesAp;


namespace ASP.Implementation.UseCasesIm.QueriesIm
{
    public class EfGetRecipeQuery : EfUseCase, IGetRecipeQuery
    {
        public EfGetRecipeQuery(TheContext context) : base(context)
        {
        }

        public int Id => 34;
        public string NameUseCase => "Search recipe";

        public string DescriptionUseCase => "Search recipe";

        public PagedResponseDto<RecipeDto> Execute(RecipeSearch search)
        {
            var query = Context.Recipes.AsQueryable();

            query = query.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.TitleRecipe))
            {
                query = query.Where(x => x.TitleRecipe.Contains(search.TitleRecipe));
            }

            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            query = query.Skip(skip).Take(perPage);


            var recipeMdto = query.Select(x => new RecipeDto
            {
               TitleRecipe  = x.TitleRecipe

            }).ToList();

            return new PagedResponseDto<RecipeDto>
            {
                CurrentPage = page,
                Data = recipeMdto,
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }

        
    }
   
}
