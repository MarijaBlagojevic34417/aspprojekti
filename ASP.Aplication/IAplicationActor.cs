using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication
{
    public interface IAplicationActor
    {
        int Id { get; }
        string Username { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
