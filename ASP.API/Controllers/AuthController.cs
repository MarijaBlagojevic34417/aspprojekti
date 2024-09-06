using ASP.API.Core;
using ASP.API.DTOauthRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenCreator _tokenCreator;
        public AuthController(JwtTokenCreator tokenCreator)
        {
            _tokenCreator = tokenCreator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            string token = _tokenCreator.Create(request.Username, request.Password);
            return Ok(new AuthResponse { Token = token });
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete([FromServices] ITokenStorage storage)
        {
            storage.Remove(this.Request.GetTokenId().Value);
            return NoContent();
        }
    }
}
