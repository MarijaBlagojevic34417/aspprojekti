using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCasesAp.QueryAp;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.Aplication.DTO.RateAp;
using ASP.Aplication.UseCasesAp.Commands.Rate;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public RateController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateRateDto dto, [FromServices] ICreateRateCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateRateDto dto,
                                                [FromServices] IUpdateRateCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteRateCommand command, DeleteRateDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }


       
    }
}
