using Microsoft.Practices.Unity;

namespace PatrolControl.UI.Screens.Common
{
    public class EditorViewModelFactory : IEditorViewModelFactory
    {
        private readonly UnityContainer _container;

        public EditorViewModelFactory(UnityContainer container)
        {
            _container = container;
        }

        public object GetEditorViewModel(object model)
        {
            return  _container.Resolve(typeof(IEditorViewModel<>)
                                           .MakeGenericType(model.GetType()), new ParameterOverride("model", model));
            
        }
    }
}