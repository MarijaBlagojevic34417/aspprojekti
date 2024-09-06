using ASP.Aplication;
using ASP.Aplication.Logging;
using ASP.DataAccess;
using ASP.Domain.Entities;

namespace ASP.API.Core
{
    public class ConsoleExceptipnLogger : IExceptionLogger

    {
        public Guid Log(Exception ex, IAplicationActor actor)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(ex.Message + " ID: " + id);

            return id;
        }
    }
    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly TheContext _context;

        public DbExceptionLogger(TheContext context)
        {
            _context = context;
        }

        public Guid Log(Exception ex, IAplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            //ID, Message, Time, StrackTrace
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };
            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
