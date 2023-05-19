namespace GrupaDotNet.CQRS.Lib.Queries
{
    public interface IQueryHandler<in TQuery, out TResult> 
        where TQuery: IQuery<TResult> 
        where TResult: class
    {
        TResult Handle(TQuery query); 
    }
}
