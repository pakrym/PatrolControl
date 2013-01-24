using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PatrolControl.UI.Framework
{
    public class ServiceBase : IService
    {
        readonly IEnumerable<MethodInfo> _methods;

        public ServiceBase()
        {
            _methods = this.GetType()
                           .GetMethods()
                           .Where(x => x.Name == "Handle");
        }

        public void Send<TService, TResponse>(IQuery<TService, TResponse> query, Action<TResponse> reply)
        {
            Invoke(query, null, query, reply);
        }

        public void Send<TService>(ICommand<TService> command, Action callback)
        {
            Invoke(command, callback, command);
        }


        void Invoke(object request, Action callback, params object[] args)
        {

            ThreadPool.QueueUserWorkItem(async state =>
            {
                var requestType = request.GetType();
                var handler = _methods.First(x => requestType.IsAssignableFrom(x.GetParameters().First().ParameterType));

                var result = handler.Invoke(this, args);
                var task = result as Task;

                if (task != null)
                    await task;

                if (callback != null)
                    callback();


            });
        }
    }
}