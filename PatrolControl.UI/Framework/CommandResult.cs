using System;
using Caliburn.Micro;
using Microsoft.Practices.Unity;

namespace PatrolControl.UI.Framework
{
    public class CommandResult<TService> : IResult where TService: IService
    {
        readonly ICommand<TService> _command;

        [Dependency]
        public TService Backend { get; set; }

        public CommandResult(ICommand<TService> command)
        {
            this._command = command;
        }

        public void Execute(ActionExecutionContext context)
        {
            Backend.Send(_command);
            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}