using ASP.Aplication.DTO.Useri;
using ASP.Aplication.DTO.UserUseCase;
using ASP.Aplication.UseCases.Commands.User;
using ASP.Aplication.UseCases.Commands.UserUseCase;
using ASP.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public UsersController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromForm] RegisterUserDto dto, [FromServices] IRegisterUserCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateUserDto dto, [FromServices] IUpdateUserCommand command)
        {
            this._useCaseHandler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        [HttpPut("{id}/access")]
        public IActionResult ModifyAccess(int id, [FromBody] UpdateUserDto dto,
                                                [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }
            [Authorize]
            [HttpPatch]
            public IActionResult Patch([FromServices] IDeleteUserCommand command, DeleteUserDto data)
            {
                _useCaseHandler.HandleCommand(command, data);
                return NoContent();
            }
            [Authorize]
           

            [HttpPut("access")]
            public IActionResult ModifyAccess(int id, [FromBody] UserUseCaseDto dto,
                                                      [FromServices] IAddUserUseCaseCommand command)
            {
                _useCaseHandler.HandleCommand(command, dto);

                return NoContent();
            }
















        }
}
