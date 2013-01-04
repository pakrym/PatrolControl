using System;
using Caliburn.Micro;

namespace PatrolControl.UI.Framework
{
    public interface IOpenResult<TTarget> : IResult
    {
        Action<TTarget> OnConfigure { get; set; }
        Action<TTarget> OnClose { get; set; }
    }
}