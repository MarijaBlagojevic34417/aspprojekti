using ASP.Aplication;

namespace ASP.API.Core
{
    public interface IExceptionLogger
    {
        Guid Log(Exception ex, IAplicationActor actor);
    }
}
