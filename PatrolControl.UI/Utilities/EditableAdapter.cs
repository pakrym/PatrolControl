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

namespace PatrolControl.UI.Utilities
{

    public class EditableAdapter<T>:EditableAdapter
    {
        public EditableAdapter(T o) : base(o)
        {
        }


    }

    public class EditableAdapter : IEditableObject, ICustomTypeProvider
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

            //Set Properties of Cache
            foreach (var info in _type.GetProperties())
            {
                if (!info.CanRead || !info.CanWrite) continue;
                var oldValue = info.GetValue(Model, null);

                info.SetValue(_cache, oldValue, null);
            }
        }

        public void EndEdit()
        {
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
    }
}
