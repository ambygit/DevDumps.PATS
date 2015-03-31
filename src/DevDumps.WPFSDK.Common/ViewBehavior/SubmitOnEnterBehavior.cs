using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace DevDumps.WPFSDK.Common.ViewBehavior
{
    public class SubmitOnEnterBehavior :  Behavior<TextBox>
    {
        public static readonly DependencyProperty SubmitCommandProperty =
            DependencyProperty.Register("SubmitCommand", typeof (ICommand), typeof (SubmitOnEnterBehavior), new PropertyMetadata(default(ICommand)));

        public ICommand SubmitCommand
        {
            get { return (ICommand) GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            var textBox = AssociatedObject;
            textBox.KeyDown+=HandleTextBoxKeyDown;
        }

        private void HandleTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnEnterKeyPress();
            }
        }

        private void OnEnterKeyPress()
        {
            var enteredValue = AssociatedObject.Text;
            if (string.IsNullOrEmpty(enteredValue)) return;
            if (SubmitCommand == null) return;

            SubmitCommand.Execute(enteredValue);
        }
    }
}
