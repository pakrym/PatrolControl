using Caliburn.Micro;

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

        //public static IResult Busy()
        //{
        //    return new BusyResult(false);
        //}

        //public static IResult NotBusy()
        //{
        //    return new BusyResult(true);
        //}
    }
}