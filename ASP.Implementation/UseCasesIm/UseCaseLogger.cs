using ASP.Aplication;
using ASP.DataAccess;
using ASP.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Implementation.UseCasesIm
{
    public class UseCaseLogger : EfUseCase,IUseCaseLogger
    {
        public UseCaseLogger(TheContext context) : base(context)
        {
        }

        public void Log(UseCaseLogg log)
        {
            UseCaseLog userUseCase = new UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData),
                ExecutedAt = DateTime.UtcNow
            };
            Context.UseCaseLogs.Add(userUseCase);
            Context.SaveChanges();
        }
    }
}
