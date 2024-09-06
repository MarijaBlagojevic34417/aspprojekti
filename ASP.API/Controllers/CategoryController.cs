using ASP.Aplication.DTO.CategoryAP;
using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Search;
using ASP.Aplication.DTO.SearchQ;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCasesAp.Commands.Category;
using ASP.Aplication.UseCasesAp.QueryAp.CategoryQ;
using ASP.Aplication.UseCasesAp.QueryAp.FoodQ;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private UseCaseHandler _useCaseHandler;

        public CategoryController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CreateCategoryDto dto, [FromServices] ICreateCategoryCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateCategoryDto dto,
                                                [FromServices] IUpdateCategoryCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        [Authorize]
        [HttpPatch]
        public IActionResult Patch([FromServices] IDeleteCategoryCommand command, DeleteCategoryDto data)
        {
            _useCaseHandler.HandleCommand(command, data);
            return NoContent();
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search, [FromServices] IGetCategoryQuery query)
      => Ok(_useCaseHandler.HandleQuery(query, search));


    }

}

