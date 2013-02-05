using System;

namespace PatrolControl.UI.Providers
{
    public class GenerateProviderAttribute : Attribute
    {
        public Type ProviderType { get; set; }

        public GenerateProviderAttribute(Type providerType)
        {
            ProviderType = providerType;
        }
    }
}