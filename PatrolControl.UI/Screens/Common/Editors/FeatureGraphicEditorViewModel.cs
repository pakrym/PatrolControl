using System.ComponentModel;
using Caliburn.Micro;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class FeatureGraphicEditorViewModel: PropertyChangedBase, IEditableObject
    {
        private readonly Feature _feature;

        public FeatureGraphicEditorViewModel(Feature feature)
        {
            _feature = feature;
        }
        
        public DbGeography Geography { get; set; }

        public virtual void BeginEdit()
        {
            Geography = _feature.Geography;
        }

        public virtual void EndEdit()
        {
            _feature.Geography = Geography;
        }

        public virtual void CancelEdit()
        {
            BeginEdit();
        }
    }
}