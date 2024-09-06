using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.DataAccess;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.UseCasesAp.QueryAp.FoodQ;

namespace ASP.Implementation.UseCasesIm.QueriesIm
{
    public class EfGetFoodQuery : EfUseCase, IGetFoodQuery
    {
        public EfGetFoodQuery(TheContext context) : base(context)
        {
        }

        public int Id => 23;
        public string NameUseCase => "Search food";

        public string DescriptionUseCase => "Search food";

        public PagedResponseDto<FoodDto> Execute(FoodSearch search)
        {
            var query = Context.Foods.AsQueryable();

            query = query.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.NameFood.Contains(search.Keyword));
            }

            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            query = query.Skip(skip).Take(perPage);


            var foodDto = query.Select(x => new FoodDto
            {
                NameFood = x.NameFood,

            }).ToList();

            return new PagedResponseDto<FoodDto>
            {
                CurrentPage = page,
                Data = foodDto,
                PerPage = perPage,
                TotalCount = totalCount,
            };
        } } }
    
