using System.ComponentModel;
using PatrolControl.UI.PatrolControlServiceReference;

namespace PatrolControl.UI.Screens.Common.Map
{
    public class FeatureViewModel : ViewModelBase, IEditableObject
    {
        private DbGeography _geography;
        public FeatureGraphic Graphic { get; set; }

        public FeatureViewModel(Entity model)
            : base(model)
        {
            FeatureModel = (Feature) model;
            Geography = FeatureModel.Geography;

            Graphic = new FeatureGraphic(this);
        }

        protected Feature FeatureModel { get; set; }

        public DbGeography Geography
        {
            get { return _geography; }
            set
            {
                if (Equals(value, _geography)) return;
                _geography = value;
                NotifyOfPropertyChange(() => Geography);
            }
        }

        public virtual void BeginEdit()
        {
            this.Geography = FeatureModel.Geography;
        }

        public virtual void EndEdit()
        {
            FeatureModel.Geography = this.Geography;
        }

        public virtual void CancelEdit()
        {
            BeginEdit();
        }
    }
}