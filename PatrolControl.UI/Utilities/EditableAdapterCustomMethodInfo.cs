using System;
using System.Globalization;
using System.Reflection;

namespace PatrolControl.UI.Utilities
{
    public class EditableAdapterCustomMethodInfo : MethodInfo
    {
        private readonly MethodInfo _methodInfo;

        public EditableAdapterCustomMethodInfo(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            return _methodInfo.GetCustomAttributes(inherit);
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
            object theobj;

            if (typeof (EditableAdapter).IsAssignableFrom(_methodInfo.DeclaringType))
            {
                theobj = obj;
            }
            else
            {
                theobj = ((EditableAdapter)obj).Model;    
            }

            return _methodInfo.Invoke(theobj, invokeAttr, binder, parameters, culture);
        }

        public override MethodInfo GetBaseDefinition()
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { return _methodInfo.Name; }
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
            get { return _methodInfo.Attributes;  }
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