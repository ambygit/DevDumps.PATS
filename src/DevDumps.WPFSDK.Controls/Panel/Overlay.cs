using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DevDumps.WPFSDK.Controls.Panel
{
    public class Overlay : ContentControl
    {
        static Overlay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Overlay), new FrameworkPropertyMetadata(typeof(Overlay)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ChangeVisualState();
        }

        public static readonly DependencyProperty IsOverlayOnProperty =
            DependencyProperty.Register("IsOverlayOn", typeof(bool), typeof(Overlay), new PropertyMetadata(default(bool), OnIsOverlayOnPropertyChanged));

        private static void OnIsOverlayOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var overlay = (Overlay)d;
            overlay.ChangeVisualState();
        }

        public bool IsOverlayOn
        {
            get { return (bool)GetValue(IsOverlayOnProperty); }
            set { SetValue(IsOverlayOnProperty, value); }
        }

        private void ChangeVisualState()
        {
            VisualStateManager.GoToState(this, IsOverlayOn ? "Visible" : "Hidden", false);
        }

        public static readonly DependencyProperty OverlayStyleProperty = DependencyProperty.Register("OverlayStyle", typeof(Style), typeof(Overlay), new PropertyMetadata(null));

        public Style OverlayStyle
        {
            get { return (Style)GetValue(OverlayStyleProperty); }
            set { SetValue(OverlayStyleProperty, value); }
        }

        public static readonly DependencyProperty OverlayContentProperty =
            DependencyProperty.Register("OverlayContent", typeof(object), typeof(Overlay), new PropertyMetadata(default(object)));

        public object OverlayContent
        {
            get { return (object)GetValue(OverlayContentProperty); }
            set { SetValue(OverlayContentProperty, value); }
        }

        public static readonly DependencyProperty OverlayContentTemplateProperty =
            DependencyProperty.Register("OverlayContentTemplate", typeof(DataTemplate), typeof(Overlay), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate OverlayContentTemplate
        {
            get { return (DataTemplate)GetValue(OverlayContentTemplateProperty); }
            set { SetValue(OverlayContentTemplateProperty, value); }
        }
    }
}
