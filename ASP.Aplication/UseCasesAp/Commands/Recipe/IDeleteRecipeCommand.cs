using ASP.Aplication.DTO.Recipe;
using ASP.Aplication.UseCasesAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCases.Commands.Recipe
{
    public interface IDeleteRecipeCommand:ICommand<DeleteRecipeDto>
    {
    }
}
