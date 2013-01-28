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
using Caliburn.Micro;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Screens.UserManager
{
    public class UserManagerViewModel : Screen
    {
        public override string DisplayName
        {
            get
            {
                return "User Manager";
            }
        }


        private Entity _selectedEntity;

        public UserManagerViewModel()
        {
            ObjectEditor = new ObjectEditorViewModel();
            ObjectEditor.Saved += ObjectSaved;
            ObjectEditor.Deleted += ObjectDeleted;
            ObjectEditor.CanDelete = true;
            //ObjectEditor.Cancelled +=ObjectEditor_Cancelled;

            EntitieCollection = new EntityCollection(new UserProvider());
            
        }

        private void ObjectDeleted(object sender, EventArgs e)
        {
            EntitieCollection.Delete(SelectedEntity);
        }

        private void ObjectSaved(object sender, EventArgs e)
        {
            EntitieCollection.SaveOrAdd(SelectedEntity);

            //restart edit
            ObjectEditor.Edit(SelectedEntity);
        }



        public EntityCollection EntitieCollection { get; set; }

        public ObjectEditorViewModel ObjectEditor { get; set; }

        public Entity SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                if (Equals(value, _selectedEntity)) return;
                _selectedEntity = value;
                NotifyOfPropertyChange(() => SelectedEntity);
                SelectedEntityChanged();
            }
        }

        public void SelectedEntityChanged()
        {
            if (SelectedEntity == null) return;
            ObjectEditor.Cancel();
            ObjectEditor.Edit(SelectedEntity);
        }

        public void Add()
        {
            SelectedEntity = EntitieCollection.New();
        }

        public IEnumerable<IResult> LoadEntities()
        {
            yield return Show.Busy("Loading ..");

            yield return new UpdateEntities() { Entities = EntitieCollection }.AsResult();

            yield return Show.NotBusy();
        }
    }

}
