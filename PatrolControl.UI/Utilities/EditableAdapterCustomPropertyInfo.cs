using System;
using System.Globalization;
using System.Reflection;

namespace PatrolControl.UI.Utilities
{
    public class EditableAdapterCustomPropertyInfo : PropertyInfo
    {
        private readonly PropertyInfo _propertyInfo;
            
        public EditableAdapterCustomPropertyInfo(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            return _propertyInfo.GetCustomAttributes(inherit);
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            var adapter = (EditableAdapter)obj;
            return _propertyInfo.GetValue(adapter.Model, invokeAttr, binder, index, culture);
        }

        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            var adapter = (EditableAdapter)obj;
            _propertyInfo.SetValue(adapter.Model, value, invokeAttr, binder, index, culture);
        }

        public override MethodInfo[] GetAccessors(bool nonPublic)
        {
            throw new NotImplementedException();
        }

        public override MethodInfo GetGetMethod(bool nonPublic)
        {
            return new EditableAdapterMethodInfo(_propertyInfo.GetGetMethod(nonPublic));
        }

        public override MethodInfo GetSetMethod(bool nonPublic)
        {
            return new EditableAdapterMethodInfo(_propertyInfo.GetSetMethod(nonPublic));
        }

        public override ParameterInfo[] GetIndexParameters()
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { return _propertyInfo.Name; }
        }

        public override Type DeclaringType
        {
            get { throw new NotImplementedException(); }
        }

        public override Type ReflectedType
        {
            get { throw new NotImplementedException(); }
        }

        public override Type PropertyType
        {
            get { return _propertyInfo.PropertyType; }
        }

        public override PropertyAttributes Attributes
        {
            get { throw new NotImplementedException(); }
        }

        public override bool CanRead
        {
            get { return _propertyInfo.CanRead; }
        }

        public override bool CanWrite
        {
            get { return _propertyInfo.CanWrite; }
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }
    }

    public class EditableAdapterMethodInfo : MethodInfo
    {
        private readonly MethodInfo _methodInfo;

        public EditableAdapterMethodInfo(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException();
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        public override ParameterInfo[] GetParameters()
        {
            throw new NotImplementedException();
        }

        public override MethodImplAttributes GetMethodImplementationFlags()
        {
            throw new NotImplementedException();
        }

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            var adapter = (EditableAdapter)obj;
            return _methodInfo.Invoke(adapter.Model, invokeAttr, binder, parameters, culture);
        }

        public override MethodInfo GetBaseDefinition()
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override Type DeclaringType
        {
            get { throw new NotImplementedException(); }
        }

        public override Type ReflectedType
        {
            get { throw new NotImplementedException(); }
        }

        public override RuntimeMethodHandle MethodHandle
        {
            get { throw new NotImplementedException(); }
        }

        public override MethodAttributes Attributes
        {
            get { return _methodInfo.Attributes; }
        }

        public override ICustomAttributeProvider ReturnTypeCustomAttributes
        {
            get { throw new NotImplementedException(); }
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }
    }
}