using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace PatrolControl.UI.Framework
{
    public class AgregatedResult : IResult
    {
        private readonly IEnumerable<IResult> _results;

        public AgregatedResult(IEnumerable<IResult> results)
        {
            _results = results;
        }

        public void Execute(ActionExecutionContext context)
        {
            Coroutine.BeginExecute(_results.GetEnumerator(), context, (sender, args) =>
                {
                    if (Completed != null)
                    {
                        Completed(this, args);
                    }
                });
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}