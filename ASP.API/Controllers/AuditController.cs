using ASP.Aplication.DTO.Search;
using ASP.Aplication.UseCasesAp.QueryAp.AuditQ;
using ASP.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private UseCaseHandler useCaseHandler;
        public AuditController(UseCaseHandler caseHandler)
        {
            useCaseHandler = caseHandler;
        }
        // GET: api/<AuditLogController>
        [HttpGet]
        public IActionResult Get([FromQuery] AuditSearchDto dto, [FromServices] IGetAuditQuery query)
        {
            return Ok(useCaseHandler.HandleQuery(query,dto));
        }

        // GET api/<AuditLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuditLogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuditLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuditLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
