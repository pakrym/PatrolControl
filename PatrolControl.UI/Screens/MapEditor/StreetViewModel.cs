using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class StreetViewModel : FeatureViewModel, IEditorViewModel<Street>
    {
        private string _name;

        public StreetViewModel(Street model)
            : base(model)
        {
            StreetgModel = model;
            _name = StreetgModel.Name;
        }

        protected Street StreetgModel { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public override void BeginEdit()
        {
            Name = StreetgModel.Name;
            base.BeginEdit();
        }

        public override void CancelEdit()
        {
            base.CancelEdit();
            BeginEdit();
        }

        public override void EndEdit()
        {
            base.EndEdit();
            StreetgModel.Name = Name;
        }
    }
}