﻿using ASP.Aplication.DTO.Useri;
using ASP.Aplication.UseCasesAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.User
{
    public interface IDeleteUserCommand:ICommand<DeleteUserDto>
    {
    }
}
