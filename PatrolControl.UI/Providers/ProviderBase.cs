using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{
    public class ProviderBase
    {
        protected PatrolControlServiceClient Client { get; set; }

        public ProviderBase()
        {
            Client = new PatrolControlServiceClient();
        }
    }
}