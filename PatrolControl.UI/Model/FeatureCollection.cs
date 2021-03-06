﻿using System;
using System.Threading.Tasks;
using ESRI.ArcGIS.Client.Geometry;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Model
{
    public class FeatureCollection<T> : ViewModelCollection<T, FeatureViewModel> where T : Feature
    {
        private readonly IFeatureProvider<T> _featureProvider;

        public FeatureCollection(IFeatureProvider<T> featureProvider, Func<T, FeatureViewModel> creator)
            : base(featureProvider,creator)
        {
            _featureProvider = featureProvider;
        }

        public async Task Update(Envelope envelope)
        {
            var features = await _featureProvider.List(envelope);

            OnAfterUpdate(features);
            SetEntities(features);
        }

    }
}