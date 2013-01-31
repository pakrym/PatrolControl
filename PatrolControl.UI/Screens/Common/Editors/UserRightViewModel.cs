using System;
using Caliburn.Micro;
using PatrolControl.UI.Model;

namespace PatrolControl.UI.Screens.Common.Editors
{
    public class UserRightViewModel : PropertyChangedBase
    {
        private readonly UserEditorViewModel _user;
        private readonly Right _right;
        private bool _allowed;

        public UserRightViewModel(UserEditorViewModel user, Right right)
        {
            _user = user;
            _right = right;

            Name = _right.Screen;

        }

        public String Name { get; set; }

        public bool Allowed
        {
            get
            {
                return (_user.Type & (1 << _right.Id)) > 0;
            }
            set
            {
                _user.Type = (_user.Type & ~(1 << _right.Id)) | (value ? 1 : 0 << _right.Id);
            }
        }
    }
}