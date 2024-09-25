using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PositionerExample_ToolbarLib.ViewModel
{
    public class NavigationControlFrame : Frame
    {
        public NavigationControlFrame()
        {
            Navigated += NavigationFrame_Navigated;
        }

        public static readonly DependencyProperty CurrentPageObjectProperty =
            DependencyProperty.Register("CurrentPageObject", typeof(object), typeof(NavigationControlFrame), new PropertyMetadata(default(object), OnCurrentPageObjectChanged));

        private static void OnCurrentPageObjectChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var navigationFrame = (NavigationControlFrame)dependencyObject;
            var newValue = dependencyPropertyChangedEventArgs.NewValue;

            if (newValue == null)
            {
                navigationFrame.Navigate(null);
                return;
            }
            navigationFrame.Navigate(newValue);
        }

        static void NavigationFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.ExtraData != null)
            {
                var control = e.Content as Page;
                control.DataContext = e.ExtraData;
            }
        }

        public object CurrentPageObject
        {
            get { return GetValue(CurrentPageObjectProperty); }
            set { SetValue(CurrentPageObjectProperty, value); }
        }
    }
}
