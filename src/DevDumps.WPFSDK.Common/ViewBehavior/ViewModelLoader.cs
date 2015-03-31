using System;
using System.Windows;
using DevDumps.WPFSDK.Core.Unity;
using Microsoft.Practices.Unity;

namespace DevDumps.WPFSDK.Common.ViewBehavior
{
    public static class ViewModelLoader
    {
        #region ViewModelType

        /// Allows to set any type, that will be injected by unity container to datacontext of the element this property is set on
        /// <summary>
        ///     ViewModelType Attached Dependency Property
        ///     Allows to set any type, that will be injected by unity container to datacontext of the element this property is set
        ///     on
        /// </summary>
        public static readonly DependencyProperty ViewModelTypeProperty =
            DependencyProperty.RegisterAttached("ViewModelType", typeof (Type), typeof (ViewModelLoader),
                new FrameworkPropertyMetadata(null,
                    OnViewModelTypeChanged));

        /// <summary>
        ///     Gets the ViewModelType property.
        /// </summary>
        public static Type GetViewModelType(DependencyObject d)
        {
            return (Type) d.GetValue(ViewModelTypeProperty);
        }

        /// <summary>
        ///     Sets the ViewModelType property.
        /// </summary>
        public static void SetViewModelType(DependencyObject d, Type value)
        {
            d.SetValue(ViewModelTypeProperty, value);
        }

        /// <summary>
        ///     Handles changes to the ViewModelType property.
        /// </summary>
        private static void OnViewModelTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement) d;
            Type type = GetViewModelType(d);


            //let the container inject the datacontext/ViewModel
            if (type != null)
                element.DataContext = UnityContainerFactory.Container.Resolve(type);
        }

        #endregion
    }
}