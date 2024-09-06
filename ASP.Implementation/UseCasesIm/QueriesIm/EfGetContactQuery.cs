using ASP.Aplication.DTO;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.UseCasesAp.QueryAp.Contact;
using ASP.DataAccess;
using ASP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm.QueriesIm
{
    public class EfGetContactQuery : EfUseCase, IGetContactQuery
    {
        public EfGetContactQuery(TheContext context) : base(context)
        {
        }

        public int Id => 25;

        public string NameUseCase =>"Search Contact";

        public string DescriptionUseCase => "Search Contact";

        public PagedResponseDto<ContactDto> Execute(SearchContactDto search)
        {
            IQueryable<Contact> query = Context.Contacts.AsQueryable();
            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Subject))
            {
                query = query.Where(x => x.Subject.ToLower().Contains(search.Subject.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Body))
            {
                query = query.Where(x => x.Body.ToLower().Contains(search.Body.ToLower()));
            }
            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            query = query.Skip(skip).Take(perPage);


            var contactDto = query.Select(x => new ContactDto
            {
                Id = x.Id,
                Subject = x.Subject,
                Name = x.Name,
                Email = x.Email,
                Body = x.Body

            }).ToList();
            return new PagedResponseDto<ContactDto>
            {
                CurrentPage = page,
                Data = contactDto,
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
