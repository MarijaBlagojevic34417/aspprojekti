using ASP.Aplication.DTO.Food;
using ASP.Aplication.UseCasesAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.Food
{
    public interface ICreateFoodCommand:ICommand<CreateFoodDto>
    {
    }
}
