using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PatrolControl.UI.Screens.Common;

namespace PatrolControl.UI.Utilities
{

    public class EditableAdapter<T> : EditableAdapter, IEditorViewModel<T>
    {
        public EditableAdapter(T model)
            : base(model)
        {
        }
    }

    public class EditableAdapter : IEditableObject, ICustomTypeProvider, INotifyPropertyChanged
    {
        private readonly Type _type;
        private object _model;
        private object _cache;

        public EditableAdapter(object o)
        {
            Model = o;
            _type = o.GetType();
        }

        public object Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public void BeginEdit()
        {
            _cache = Activator.CreateInstance(_type);

            var npc = Model as INotifyPropertyChanged;
            if (npc != null)
            {
                npc.PropertyChanged += ModelPropertyChanged;
            }
            //Set Properties of Cache
            foreach (var info in _type.GetProperties())
            {
                if (!info.CanRead || !info.CanWrite) continue;
                var oldValue = info.GetValue(Model, null);

                info.SetValue(_cache, oldValue, null);
            }
        }

        private void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e);
        }

        public void EndEdit()
        {
            var npc = Model as INotifyPropertyChanged;
            if (npc != null)
            {
                npc.PropertyChanged -= ModelPropertyChanged;
            }

            Model = null;
            _cache = null;
        }

        public void CancelEdit()
        {
            foreach (var info in _type.GetProperties())
            {
                if (!info.CanRead || !info.CanWrite) continue;
                var oldValue = info.GetValue(_cache, null);
                info.SetValue(Model, oldValue, null);
            }
        }

        public Type GetCustomType()
        {
            return new EditableAdapterCustomType(_type);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }

        public static object CreateGeneric(object o)
        {
            if (o == null) throw new ArgumentNullException("o");

            return Activator.CreateInstance(typeof(EditableAdapter<>).MakeGenericType(o.GetType()),o);
        }
    }
}
