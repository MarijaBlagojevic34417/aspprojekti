using ASP.Aplication.UseCasesAp.DTOucap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.Search
{
    public class AuditSearchDto : PagedSearch
    {
        public string? UserName { get; set; }
        public string? UseCaseName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
    public class AuditDto : BaseDto
    {
        public string UseCaseName { get; set; }
        public string UserName { get; set; }
        public string UserCaseData { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}
