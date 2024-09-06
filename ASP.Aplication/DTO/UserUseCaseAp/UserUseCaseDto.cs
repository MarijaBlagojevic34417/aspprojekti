using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.DTO.UserUseCase
{
    public class UserUseCaseDto
    {
        public int IdUser { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }

}
