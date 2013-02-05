using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Providers
{

    [GenerateProvider(typeof(ICrud<User>))]
    public partial class UserProvider 
    {
    }
}