using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCasesAp
{
    public interface IQuery<TResult, TSearch> : IUseCase
    {

        //tip povratne vrednosti
        TResult Execute(TSearch search);
    }
}
