using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.MapEditor;
using PatrolControl.UI.Screens.Shell;
using PatrolControl.UI.Services;
using PatrolControl.UI.Utilities;

namespace PatrolControl.UI.Screens.Login
{
    public class LoginScreenViewModel : Screen, INotifyDataErrorInfo
    {
        public LoginScreenViewModel()
        {
            Screens = new ObservableCollection<IScreen>();
            Users = new ObservableCollection<User>();
            ShowScreens = false;
        }

        public ObservableCollection<IScreen> Screens { get; set; }
        public ObservableCollection<User> Users { get; set; }

        private bool _showScreens;
        private string _error;

        public bool ShowScreens
        {
            get { return _showScreens; }
            set
            {
                if (value.Equals(_showScreens)) return;
                _showScreens = value;
                NotifyOfPropertyChange(() => ShowScreens);
            }
        }

        public User Login { get; set; }

        public string Password { get; set; }

        public string Error
        {
            get { return _error; }
            set
            {
                if (value == _error) return;
                _error = value;
                NotifyOfPropertyChange(() => Error);
                OnErrorsChanged(new DataErrorsChangedEventArgs("Password"));
            }
        }

        [Dependency]
        public Func<MapEditorScreenViewModel> MapEditorScreen { get; set; }

        public IEnumerable<IResult> DoLogin()
        {
            ShowScreens = false;
            Error = null;

            var loginUser = new LoginUser() { Login = Login.Name, Password = Password }.AsResult();
            yield return loginUser;
            if (loginUser.Response == null)
            {
                Error = "Invalid password";

            }
            else
            {
                var getScreens = new GetScreensForUser() { Permissions = loginUser.Response.Type }.AsResult();
                yield return getScreens;

                Screens.Clear();
                foreach (var screen in getScreens.Response)
                {
                    Screens.Add(screen);
                }
                ShowScreens = true;
            }
        }

        public IResult Proceed(IScreen screen)
        {
            return Show.Child(screen).In<IShell>();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName == "Password")
            {
                return new[] { Error };
            }
            return null;
        }

        public bool HasErrors
        {
            get { return Error != null; }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            EventHandler<DataErrorsChangedEventArgs> handler = ErrorsChanged;
            if (handler != null) handler(this, e);
        }

        protected override void OnInitialize()
        {
            Caliburn.Micro.Coroutine.BeginExecute(LoadUsers().GetEnumerator());
            base.OnInitialize();
        }

        private IEnumerable<IResult> LoadUsers()
        {
            yield return Show.Busy("Loading users...");

            var getUsers = new GetLoginUsers().AsResult();
            yield return getUsers;

            foreach (var user in getUsers.Response)
            {
                Users.Add(user);
            }

            yield return Show.NotBusy();
        }
    }
}
