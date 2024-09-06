using ASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm
{
    public abstract class EfUseCase
    {
        private readonly TheContext _context;

        protected EfUseCase(TheContext context)
        {
            _context = context;
        }

        protected TheContext Context => _context;
    }
}
