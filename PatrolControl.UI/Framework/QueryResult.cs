using System;
using Caliburn.Micro;
using Microsoft.Practices.Unity;

namespace PatrolControl.UI.Framework
{
    public class QueryResult<TService, TResponse> : IResult where TService:IService
    {
        readonly IQuery<TService, TResponse> _query;

        public QueryResult(IQuery<TService, TResponse> query)
        {
            this._query = query;
        }

        [Dependency]
        public TService Backend { get; set; }

        public TResponse Response { get; set; }

        public void Execute(ActionExecutionContext context)
        {
            Backend.Send(_query, response =>
                {
                    Response = response;
                    Caliburn.Micro.Execute.OnUIThread(() => Completed(this, new ResultCompletionEventArgs()));
                });
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}