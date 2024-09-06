using ASP.Aplication.DTO.Food;
using ASP.Aplication.DTO.Image;
using ASP.Aplication.UseCasesAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.Image
{
    public interface IDeleteImageCommand:ICommand<DeleteFoodDto>
    {
    }
}
