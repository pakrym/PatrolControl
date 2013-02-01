using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{

    public interface IUserProvider: ICrud
    {
        
    }

    public partial class UserProvider: ProviderBase, IUserProvider 
    {
 
    }
}