using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCasesAp
{
    public interface ICommand<T> : IUseCase
    {
        //tip povratne vrednosti bi bilo upisivanje, update, delete, ... 
        //ulazni parametar u komadnu objekat korisnika, intiger kao id u komandi za brisanje, 
        //ovo je opsta komadnda i najapstrakcija, dto ce biti ulazni parametar za na primer registraciju
        void Execute(T request);
    }
}
