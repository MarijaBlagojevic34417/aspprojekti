using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.DTO.Useri;
using ASP.Aplication.DTO.UserUseCase;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCases.Commands.User;
using ASP.Aplication.UseCases.Commands.UserUseCase;
using ASP.Aplication.UseCasesAp.QueryAp.FoodQ;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public FoodController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateFoodDto dto, [FromServices] ICreateFoodCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateFoodDto dto,
                                                [FromServices] IUpdateFoodCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteFoodCommand command, DeleteFoodDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] FoodSearch search, [FromServices] IGetFoodQuery query)
      => Ok(_useCaseHandler.HandleQuery(query, search));


    }


}

