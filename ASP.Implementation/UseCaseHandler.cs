using ASP.Aplication;
using ASP.Aplication.Logging;
using ASP.Aplication.UseCasesAp;
using Azure.Core;
using System.Diagnostics;

namespace ASP.Implementation
{
    public class UseCaseHandler
    {



        private readonly IAplicationActor _actor;
        private readonly IUseCaseLogger _logger;


        public UseCaseHandler(IAplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TData>(ICommand<TData> command, TData data)
        {
            HandleCCC(command, data);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            command.Execute(data);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {command.NameUseCase}, {stopwatch.ElapsedMilliseconds} ms");
        }
        public TResponse HandleQuery<TResponse, TSearch>(IQuery<TResponse, TSearch> query, TSearch search)
         where TResponse : class

        {
            HandleCCC(query, search);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = query.Execute(search);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {query.NameUseCase}, {stopwatch.ElapsedMilliseconds} ms");

            return result;
        }

        private void HandleCCC(IUseCase useCase, object data)
        {
            if (!_actor.AllowedUseCases.Contains(useCase.Id))
            {
                throw new UnauthorizedAccessException();
            }

            UseCaseLogg log = new UseCaseLogg
            {
                UseCaseData = data,
                UseCaseName = useCase.NameUseCase,
                Username = _actor.Username
            };

            _logger.Log(log);
        }


































        /* private IExceptionLogger _logger;


         public void HandleCommand<TRequest>(System.Windows.Input.ICommand command, TRequest data)
         {
             //exception handler
             try
             {
                 var tajmer = new Stopwatch();
                 tajmer.Start();
                 command.Execute(data);
                 tajmer.Stop();


             }
             catch (Exception ex)
             {

                 //vkonstruktor
                 _logger.Log(ex);


                 throw;
             }

         }
         /*
          public void HandleCommand(ICreateCategoryCommand command, CategoryDto dto)
          {
              throw new NotImplementedException();
          }
         *}
         //jedan metod za rad sa kverijem i jedan za komand 
         public void HandleCommand<TData>(ICommand<TData> command, TData data)
         {
             HandleCCC(command, data);

             Stopwatch stopwatch = new Stopwatch();
             stopwatch.Start();

             command.Execute(data);

             stopwatch.Stop();

             Console.WriteLine($"UseCase: {command.NameUseCase}, {stopwatch.ElapsedMilliseconds} ms");
         }
         public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
         {
             //exception handler
             try
             {
                 var tajmer = new Stopwatch();
                 tajmer.Start();
                 var response = query.Execute(data);


                 tajmer.Stop();

                 return response;
             }
             catch (Exception ex)
             {


                 _logger.Log(ex);


                 throw;
             }

         }

     }*/
    }
}