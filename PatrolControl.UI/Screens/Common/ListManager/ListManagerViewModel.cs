using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Microsoft.Practices.Unity;
using PatrolControl.UI.Framework;
using PatrolControl.UI.Model;
using PatrolControl.UI.Model.Commands;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;

namespace PatrolControl.UI.Screens.Common.ListManager
{
    public class ListManagerViewModel<TE,TM> : Screen 
        where TM : ViewModelBase 
        where TE : Entity

    {
        private TE _selectedEntity;
        private bool _noDeselectOnCancel = false;

        public ListManagerViewModel(ICrud<TE> crud, ObjectEditorViewModel objectEditorViewModel, Func<TE, TM> vmCreator)
        {

            ObjectEditor = objectEditorViewModel;
            ObjectEditor.Saved += ObjectSaved;
            ObjectEditor.Deleted += ObjectDeleted;
            ObjectEditor.Cancelled += ObjectCanceled;
            ObjectEditor.CanDelete = true;
            //ObjectEditor.Cancelled +=ObjectEditor_Cancelled;

            EntitieCollection = new ViewModelCollection<TE, TM>(crud, vmCreator);

        }

        private void ObjectCanceled(object sender, EventArgs e)
        {
            if (!_noDeselectOnCancel)
                SelectedEntity = null;
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

        public ViewModelCollection<TE, TM> EntitieCollection { get; set; }

        public ObjectEditorViewModel ObjectEditor { get; private set; }

        public TE SelectedEntity
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
            _noDeselectOnCancel = true;
            ObjectEditor.Cancel();
            _noDeselectOnCancel = false;
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