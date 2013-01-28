using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace PatrolControl.UI.Framework
{
    public static class BackendUiExtensions
    {
        public static QueryResult<TService, TResponse> AsResult<TService, TResponse>(
            this IQuery<TService, TResponse> query) where TService : IService
        {
            return new QueryResult<TService, TResponse>(query);
        }

        public static CommandResult<TService> AsResult<TService>(this ICommand<TService> command)
            where TService : IService
        {
            return new CommandResult<TService>(command);
        }

        public static AgregatedResult AsResult(this IEnumerable<IResult> results)
        {
            return new AgregatedResult(results);
        }
    }

}