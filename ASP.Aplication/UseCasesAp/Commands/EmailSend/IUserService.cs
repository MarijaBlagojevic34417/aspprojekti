using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.EmailSend
{
    public interface IUserService
    {
        string GetUserEmailById(int userId);
    }
}
