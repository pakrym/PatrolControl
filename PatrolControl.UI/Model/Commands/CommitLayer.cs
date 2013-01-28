﻿using PatrolControl.UI.Framework;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Services;

namespace PatrolControl.UI.Model.Commands
{
    public class CommitLayer : ICommand<IFeatureService>
    {
        public FeatureLayerViewModel FeatureLayer { get; set; }
    }
}