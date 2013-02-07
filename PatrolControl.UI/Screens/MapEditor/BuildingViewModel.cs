using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common.Map;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class BuildingViewModel : FeatureViewModel
    {
        private string _number;

        private int _streetId;

        public BuildingViewModel(Building model)
            : base(model)
        {
            BuildingModel = model;
            Number = BuildingModel.Number;
        }

        protected Building BuildingModel { get; set; }


        public string Number
        {
            get { return _number; }
            set
            {
                if (value == _number) return;
                _number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }

        public int StreetId
        {
            get { return _streetId; }
            set
            {
                if (value == _streetId) return;
                _streetId = value;
                NotifyOfPropertyChange(() => StreetId);
            }
        }

        public override void BeginEdit()
        {
            Number = BuildingModel.Number;
            StreetId = BuildingModel.StreetId;
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
            BuildingModel.Number = Number;
            BuildingModel.StreetId = StreetId;
        }
    }
}