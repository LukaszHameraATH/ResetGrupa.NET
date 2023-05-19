namespace GrupaDotNet.CQRS.Lib.Queries
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult> 
            where TResult : class;
    }
}
