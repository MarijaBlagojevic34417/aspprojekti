using ASP.Aplication.DTO;
using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.UseCasesAp.QueryAp.AuditQ;
using ASP.DataAccess;
using ASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.QueriesIm
{
    public class EfGetAudit : EfUseCase,IGetAuditQuery
    {
        public EfGetAudit(TheContext context) : base(context)
        {
        }

        public int Id => 24;

        public string NameUseCase => "Audit Log";

        public string DescriptionUseCase => "Audit Log";

        public PagedResponseDto<AuditDto> Execute(AuditSearchDto search)
        {
            IQueryable<UseCaseLog> query = Context.UseCaseLogs.AsQueryable();
            if (!string.IsNullOrEmpty(search.UserName))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.UserName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }
            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.ExecutedAt >= search.DateFrom);
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.ExecutedAt <= search.DateTo);
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            query = query.Skip(skip).Take(perPage);


            var auditDto = query.Select(x => new AuditDto
            {
              Id = x.Id,
              UseCaseName=x.UseCaseName,
              ExecutedAt = x.ExecutedAt,
              UserCaseData=x.UseCaseData,
              UserName=x.Username

            }).ToList();
            return new PagedResponseDto<AuditDto>
            {
                CurrentPage = page,
                Data = auditDto,
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
