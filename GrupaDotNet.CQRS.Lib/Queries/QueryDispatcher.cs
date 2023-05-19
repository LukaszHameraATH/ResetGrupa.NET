using GrupaDotNet.CQRS.Lib.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace GrupaDotNet.CQRS.Lib.Queries
{
    public class QueryDispatcher: IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TQuery, TResult>(TQuery query) 
            where TQuery : IQuery<TResult> 
            where TResult : class
        {
            using var scope = _serviceProvider.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.Handle(query);
        }
    }
}
