using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.ReactionAp;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCasesAp.Commands.Reaction;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public ReactionController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateReactionDto dto, [FromServices] ICreateReactionCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateReactionDto dto,
                                                [FromServices] IUpdateReactionCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteReactionCommand command, DeleteReactionDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }



    }
}
