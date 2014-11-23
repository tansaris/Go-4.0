using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AdvComProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapOrResource : Page
    {
        public string courseId;
        public MapOrResource()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                courseId = e.Parameter.ToString();
            }
        }


        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HubPage));
        }



        private void map_button(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Map), courseId);
        }

        private void resource_button(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Resource), courseId);
        }
    }
}
