using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Domain.Entities
{
    public class UserUseCase
    {
        public int IdUserUseCase { get; set; }
        public int IdUser { get; set; }
        public int IdUseCase { get; set; }

        public virtual User User { get; set; }

    }
}
