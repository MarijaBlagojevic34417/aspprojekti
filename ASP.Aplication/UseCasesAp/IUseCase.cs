using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCasesAp
{
    public interface IUseCase
    {
        public int Id { get; }
        string NameUseCase { get; }
        //svaki slucaj moze imati opis
        string DescriptionUseCase { get; }

    }
}
