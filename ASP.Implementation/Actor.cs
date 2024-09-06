using ASP.Aplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation
{
    public class Actor : IAplicationActor
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }

    public class UnauthorizedActor : IAplicationActor
    {

        public int Id => 0;

        public string Username => "unauthorized";

        public string FirstName => "unauthorized";

        public string LastName => "unauthorized";

        public string Email => "/";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,10 };
    }
}
