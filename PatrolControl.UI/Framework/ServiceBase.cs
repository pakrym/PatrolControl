using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace PatrolControl.UI.Framework
{
    public class ServiceBase: IService
    {
        readonly IEnumerable<MethodInfo> _methods;

        public ServiceBase()
        {
            _methods = this.GetType()
                           .GetMethods()
                           .Where(x => x.Name == "Handle");
        }

        public void Send<TService, TResponse>(IQuery<TService, TResponse> query, Action<TResponse> reply) {
            Invoke(query, query, reply);
        }

        public void Send<TService>(ICommand<TService> command) {
            Invoke(command, command);
        }

        void Invoke(object request, params object[] args) {
            ThreadPool.QueueUserWorkItem(state => {
                                                      var requestType = request.GetType();
                                                      var handler = _methods.Where(x => requestType.IsAssignableFrom(x.GetParameters().First().ParameterType)).First();

                                                      handler.Invoke(this, args);
            });
        }
    }
}