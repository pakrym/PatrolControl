using System;

namespace PatrolControl.UI.Framework
{
    public interface IService
    {
        void Send<TService, TResponse>(IQuery<TService, TResponse> query, Action<TResponse> callback);

        void Send<TService>(ICommand<TService> command, Action callback);
    }
}