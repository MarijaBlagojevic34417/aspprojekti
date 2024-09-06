using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCasesAp.QueryAp;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.UseCasesAp.Commands.Recipe;
using ASP.Aplication.UseCases.Commands.Recipe;
using ASP.Aplication.DTO.Useri;
using ASP.Aplication.UseCases.Commands.User;
using ASP.Aplication.DTO.SearchQ;
using ASP.Aplication.UseCasesAp.QueryAp.RecipeQ;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public RecipeController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateRecipeDto dto, [FromServices] ICreateRecipeCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateRecipeDto dto, [FromServices] IUpdateRecipeCommand command)
        {
            this._useCaseHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateRecipeDto dto,
                                                [FromServices] IUpdateRecipeCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteRecipeCommand command, DeleteRecipeDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] RecipeSearch search, [FromServices] IGetRecipeQuery query)
      => Ok(_useCaseHandler.HandleQuery(query, search));
       

    }

}

