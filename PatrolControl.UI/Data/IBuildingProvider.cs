using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Data
{


    public interface IBuildingProvider
    {
        void GetBuilding(Action<IEnumerable<Building>> callback);
    }

    class BuildingProvider : IBuildingProvider
    {
        public void GetBuilding(Action<IEnumerable<Building>> callback)
        {
            var client = new PatrolControlServiceClient();
            client.GetBuildingsCompleted += ((sender, args) => callback(args.Result));
            client.GetBuildingsAsync();
        }
    }
}
