using Caliburn.Micro;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;

namespace PatrolControl.UI.Framework
{
    public static class Show
    {
        public static OpenChildResult<TChild> Child<TChild>()
            where TChild : IScreen
        {
            return new OpenChildResult<TChild>();
        }

        public static OpenChildResult<TChild> Child<TChild>(TChild child)
           where TChild : IScreen
        {
            return new OpenChildResult<TChild>(child);
        }

        public static IResult Busy(string text)
        {
            return new SetBusy() { Status = true, Text = text }.AsResult();
        }

        public static IResult NotBusy()
        {
            return new SetBusy() { Status = false }.AsResult();
        }
    }
}