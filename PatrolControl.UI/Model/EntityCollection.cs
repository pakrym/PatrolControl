using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using PatrolControl.UI.PatrolControlServiceReference;
using PatrolControl.UI.Providers;

namespace PatrolControl.UI.Model
{
    public class EntityCollection
    {
        private List<Entity> _deleted;

        private readonly ICrud _crud;

        public EntityCollection(ICrud crud)
        {
            Entities = new ObservableCollection<Entity>();
            _deleted = new List<Entity>();
            _crud = crud;
        }

        public ObservableCollection<Entity> Entities { get; set; }

        protected virtual void OnPreCommit() { }

        protected virtual void OnAfterUpdate(IEnumerable<Entity> entities) { }

        public Entity New()
        {
            return _crud.New();
        }

        public void SaveOrAdd(Entity entity)
        {
            if (entity.State == EntityState.New)
            {
                Entities.Add(entity);
                entity.State = EntityState.Added;
            }
            else
            {
                if (entity.State != EntityState.Added)
                    entity.State = EntityState.Edited;
            }

        }

        public void Delete(Entity entity)
        {
            entity.State = EntityState.Deleted;

            Entities.Remove(entity);
            _deleted.Add(entity);
        }

        public async Task Update()
        {
            var features = await _crud.List();

            OnAfterUpdate(features);
            Execute.OnUIThread(()=>SetEntities(features));
        }

        public async Task Commit()
        {
            OnPreCommit();

            await _crud.Add(Entities.Where(e => e.State == EntityState.Added).ToArray());
            await _crud.Save(Entities.Where(e => e.State == EntityState.Edited).ToArray());
            
            await _crud.Remove(_deleted.ToArray());
            _deleted.Clear();

            foreach (var entity in Entities )
            {
                entity.State = EntityState.NotChanged;
            }

        }

        protected void SetEntities(IEnumerable<Entity> entities)
        {
            Entities.Clear();
            foreach (var feature in entities)
            {
                feature.State = EntityState.NotChanged;
                Entities.Add(feature);
            }
        }
    }
}