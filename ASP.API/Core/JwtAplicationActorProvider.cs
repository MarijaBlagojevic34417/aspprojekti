using ASP.Aplication;
using ASP.Implementation;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace ASP.API.Core
{
    public class JwtAplicationActorProvider : IAplicationProvider
    {
        private string authorizationHeader;

        public JwtAplicationActorProvider(string authorizationHeader)
        {
            this.authorizationHeader = authorizationHeader;
        }
        public IAplicationActor GetActor()
        {
            if (authorizationHeader.Split("Bearer ").Length != 2)
            {
                return new UnauthorizedActor();
            }

            string token = authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var actor = new Actor
            {
                Username = claims.First(x => x.Type == "Username").Value,
                FirstName = claims.First(x => x.Type == "FirstName").Value,
                LastName = claims.First(x => x.Type == "LastName").Value,
                Email = claims.First(x => x.Type == "Email").Value,

                Id = int.Parse(claims.First(x => x.Type == "Id").Value),
                AllowedUseCases = JsonConvert.DeserializeObject<List<int>>(claims.First(x => x.Type == "UseCaseIds").Value)
            };

            return actor;
        }
    }
}
