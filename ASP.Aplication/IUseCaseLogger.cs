using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLogg log);
    }

    public class UseCaseLogg
    {
        public string Username { get; set; }
        public string UseCaseName { get; set; }
        public object UseCaseData { get; set; }
    }
}
