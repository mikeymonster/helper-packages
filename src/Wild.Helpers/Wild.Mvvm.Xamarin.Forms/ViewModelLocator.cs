using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Wild.Mvvm.Xamarin.Forms
{
    //Some details on how this works:
    //https://forums.xamarin.com/discussion/37354/viewmodellocator-reference-in-xaml
    //https://marcduerst.com/2020/01/18/inject-xamarin-forms-view-models-via-ioc-container/
    //https://www.javatpoint.com/xamarin-model-view-viewmodel-pattern

    public class ViewModelLocator
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    throw new InvalidOperationException(
                        "ServiceProvider not set in ViewModelLocator. " +
                        "Make sure the ServiceProvider is set in the startup class.");
                }
                return _serviceProvider;
            }
            set => _serviceProvider = value;
        }

        public static readonly BindableProperty AutowireViewModelProperty =
            BindableProperty.CreateAttached(
                "AutowireViewModel",
                typeof(bool),
                typeof(ViewModelLocator),
                default(bool),
                propertyChanged: OnAutowireViewModelChanged);

        public static bool GetAutowireViewModel(BindableObject bindable)
            => (bool)bindable.GetValue(AutowireViewModelProperty);

        public static void SetAutowireViewModel(BindableObject bindable, bool value)
            => bindable.SetValue(AutowireViewModelProperty, value);

        public static readonly BindableProperty ViewModelTypeProperty =
            BindableProperty.CreateAttached(
                "ViewModelType",
                typeof(Type),
                typeof(ViewModelLocator),
                default(Type),
                propertyChanged: OnViewModelTypeChanged);

        public static Type GetViewModelType(BindableObject bindable)
            => (Type)bindable.GetValue(ViewModelTypeProperty);

        public static void SetViewModelType(BindableObject bindable, Type value)
            => bindable.SetValue(ViewModelTypeProperty, value);

        public static object Resolve(Type type) => ServiceProvider.GetService(type);

        public static T Resolve<T>() where T : class => (T)ServiceProvider.GetService(typeof(T));

        private static void OnAutowireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bool)newValue)
            {
                return;
            }

            var view = bindable as Element;

            var viewType = view?.GetType();
            if (viewType?.FullName == null)
            {
                return;
            }

            //NOTE: This only works if views and view models are in the same assembly
            //      and the viewmodel ha the same name as the view, with "ViewModel" appended
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName,
                viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            view.BindingContext = Resolve(viewModelType);
        }

        private static void OnViewModelTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            if (!(newValue is Type viewModelType))
            {
                return;
            }

            view.BindingContext = Resolve(viewModelType);
        }
    }
}
