using ASP.Aplication.DTO.UserUseCase;
using ASP.Aplication.UseCasesAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.UserUseCase
{
    public interface IAddUserUseCaseCommand : ICommand<UserUseCaseDto>
    {
    }
}
