using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;
using PatrolControl.UI.Screens.Common;
using PatrolControl.UI.Screens.Common.Map;

namespace PatrolControl.UI.Model
{

    public class ViewModelCollection<TE, TM>
        where TM : ViewModelBase
        where TE : Entity
    {
        private List<TM> _deleted;

        private readonly ICrud<TE> _crud;
        private readonly Func<TE, TM> _creator;

        public ViewModelCollection(ICrud<TE> crud, Func<TE, TM> creator)
        {
            Entities = new ObservableCollection<TM>();
            _deleted = new List<TM>();
            _crud = crud;
            _creator = creator;
        }

       public ObservableCollection<TM> Entities { get; set; }

        protected virtual void OnPreCommit() { }

        protected virtual void OnAfterUpdate(IEnumerable<Entity> entities) { }

        public TM New()
        {
            return _creator(_crud.New());
        }

        public void SaveOrAdd(TM entity)
        {
            if (entity.Model.State == EntityState.New)
            {
                Entities.Add(entity);
                entity.Model.State = EntityState.Added;
            }
            else
            {
                if (entity.Model.State != EntityState.Added)
                    entity.Model.State = EntityState.Edited;
            }

        }

        public void Delete(TM entity)
        {
            entity.Model.State = EntityState.Deleted;

            Entities.Remove(entity);
            _deleted.Add(entity);
        }

        public async Task Update()
        {
            var features = await _crud.List();

            OnAfterUpdate(features);
            Execute.OnUIThread(() => SetEntities(features));
        }

        public async Task Commit()
        {
            OnPreCommit();

            await _crud.Add(Entities.Where(e => e.Model.State == EntityState.Added).Select(e => (TE)e.Model).ToArray());
            await _crud.Save(Entities.Where(e => e.Model.State == EntityState.Edited).Select(e => (TE)e.Model).ToArray());

            await _crud.Remove(_deleted.Select(e => (TE)e.Model).ToArray());
            _deleted.Clear();

            foreach (var entity in Entities)
            {
                entity.Model.State = EntityState.NotChanged;
            }

        }

        protected void SetEntities(IEnumerable<TE> entities)
        {
            Entities.Clear();
            foreach (var feature in entities)
            {
                feature.State = EntityState.NotChanged;
                Entities.Add(_creator(feature));
            }
        }
    }
}