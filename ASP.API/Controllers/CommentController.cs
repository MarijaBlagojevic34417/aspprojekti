using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO;
using ASP.Aplication.UseCases.Commands.Food;
using ASP.Aplication.UseCasesAp.QueryAp;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.Aplication.DTO.Comment;
using ASP.Aplication.UseCases.Commands.Comment;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private UseCaseHandler _useCaseHandler;

        public CommentController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

       
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto dto,
                              [FromServices] ICreateCommentCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteCommentDto dto,
                          [FromServices] IDeleteCommentCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFood(int id, [FromBody] CommentDto dto,
                                              [FromServices] IUpdateCommentCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }



    }
}
