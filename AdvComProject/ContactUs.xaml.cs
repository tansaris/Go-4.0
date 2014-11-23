using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class ContactUs : Page
    {
        public double lat;
        public double lng;
        public ContactUs()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get this from the Dev Center before
            // distributing your app.
            //MyMap.MapServiceToken = "YOURMAPSERVICETOKEN";


            //Set default zoom level, the farther the less and vice versa
            locmap.ZoomLevel = 5;



            Geolocator locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;
            //Geoposition position = await locator.GetGeopositionAsync();

            // MUST ENABLE THE LOCATION CAPABILITY!!!
            var position = await locator.GetGeopositionAsync();
            lat = position.Coordinate.Latitude;
            lng = position.Coordinate.Longitude;
            await locmap.TrySetViewAsync(position.Coordinate.Point, 18D);

            slider1.Value = locmap.ZoomLevel;

        }

        private void companyPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Geolocator locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;
            lat = 13.7372;
            lng = 100.5327;
            var compPosition = new Windows.Devices.Geolocation.BasicGeoposition();
            compPosition.Latitude = lat;
            compPosition.Longitude = lng;
            //set map point
            locmap.Center = new Windows.Devices.Geolocation.Geopoint(compPosition);


            //FORMAPICON
            MapPolygon polygon = new MapPolygon();
            polygon.FillColor = Windows.UI.Colors.Green;
            polygon.StrokeColor = Windows.UI.Colors.Blue;
            polygon.StrokeThickness = 5;
            List<BasicGeoposition> positions = new List<BasicGeoposition>();
            positions.Add(new BasicGeoposition() { Latitude = lat, Longitude = lng });
            positions.Add(new BasicGeoposition() { Latitude = lat + 1, Longitude = lng + 1 });
            //positions.Add(new BasicGeoposition() { Latitude = lat-1, Longitude = lng });
            //Geocoordinate
            polygon.Path = new Geopath(positions);
            MapIcon icon = new MapIcon();
            icon.Title = "GROUP2 OFFICE";
            icon.Location = new Geopoint(positions.ElementAt<BasicGeoposition>(0));
            icon.NormalizedAnchorPoint = new Point(0.5, 0.5);
            Image img = new Image();
            //BitmapImage src = new BitmapImage();
            //src.SetSource(Application.GetResourceStream(new Uri(@"Assets/DarkGray.png", UriKind.RelativeOrAbsolute)).Stream);
            //img.Source = src;
            icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Circle.png"));
            locmap.LandmarksVisible = true;
            locmap.MapElements.Add(polygon);
            locmap.MapElements.Add(icon);

            //
        }

        private async void setPositionButton_Click(object sender, RoutedEventArgs e)
        {

            Geolocator locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;
            //Geoposition position = await locator.GetGeopositionAsync();

            // MUST ENABLE THE LOCATION CAPABILITY!!!
            var position = await locator.GetGeopositionAsync();
            lat = position.Coordinate.Latitude;
            lng = position.Coordinate.Longitude;
            var myPosition = new BasicGeoposition();
            myPosition.Latitude = lat;
            myPosition.Longitude = lng;

            var myPoint = new Geopoint(myPosition);

            //set map point
            locmap.Center = myPoint;



            //FORMAPICON
            MapPolygon polygon = new MapPolygon();
            polygon.FillColor = Windows.UI.Colors.Green;
            polygon.StrokeColor = Windows.UI.Colors.Blue;
            polygon.StrokeThickness = 5;
            List<BasicGeoposition> positions = new List<BasicGeoposition>();
            positions.Add(new BasicGeoposition() { Latitude = lat, Longitude = lng });
            positions.Add(new BasicGeoposition() { Latitude = lat + 1, Longitude = lng + 1 });
            //positions.Add(new BasicGeoposition() { Latitude = lat-1, Longitude = lng });
            //Geocoordinate
            polygon.Path = new Geopath(positions);
            MapIcon icon = new MapIcon();
            icon.Title = "YOU ARE HERE";
            icon.Location = new Geopoint(positions.ElementAt<BasicGeoposition>(0));
            icon.NormalizedAnchorPoint = new Point(0.5, 0.5);
            Image img = new Image();
            //BitmapImage src = new BitmapImage();
            //src.SetSource(Application.GetResourceStream(new Uri(@"Assets/DarkGray.png", UriKind.RelativeOrAbsolute)).Stream);
            //img.Source = src;
            icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Circle.png"));
            locmap.LandmarksVisible = true;
            locmap.MapElements.Add(polygon);
            locmap.MapElements.Add(icon);

            //

        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (locmap != null)
                locmap.ZoomLevel = e.NewValue;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HubPage));
        }
    }
}
