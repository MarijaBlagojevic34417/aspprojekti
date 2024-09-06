using ASP.Aplication.DTO.Comment;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.UseCases.Commands.Comment;
using ASP.Aplication.UseCasesAp.Commands.Contact;
using ASP.Aplication.UseCasesAp.QueryAp.Contact;
using ASP.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/<ContactController>
        private UseCaseHandler _useCaseHandler;
        public ContactController(UseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }
        [HttpGet]
        public IActionResult Get([FromQuery]SearchContactDto dto, [FromServices]IGetContactQuery query)
        {
            return Ok(this._useCaseHandler.HandleQuery(query,dto));
        }
        

        

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] ContactDto dto,
                              [FromServices] ICreateContactCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }
    }
}
