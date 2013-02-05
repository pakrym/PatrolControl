using PatrolControl.UI.Model;

namespace PatrolControl.UI.Providers
{
    public interface IRightProvider
    {
        Right[] GetAllRights();
    }

    public class RightProvider : IRightProvider
    {
        public Right[] GetAllRights()
        {
            return new[]
                {
                     new Right(0, "mapeditor"),
                        new Right(1, "usermanager"),
                        //new Right(2, "operationscreen"),
                        new Right(3, "officermanager")
                };
        }
    }
}