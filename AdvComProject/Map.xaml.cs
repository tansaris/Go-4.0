using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AdvComProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        public JsonArray jsonArray;
        public string courseId;
        public Map()
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
            courseId = e.Parameter.ToString();
            ShowMyLocationOnTheMap();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapOrResource), courseId);
        }
        private async void getData()
        {
            var client = new HttpClient(); // Add: using System.Net.Http;
            var response = await client.GetAsync(new Uri("http://tanwebsite.me/groupstudy/groupStudyMap.php"));
            var jsonText = await response.Content.ReadAsStringAsync();
            jsonArray = JsonArray.Parse(jsonText);
            foreach (JsonValue jsonValue in jsonArray)
            {
                JsonObject jsonObject = jsonValue.GetObject();
                string coursename = jsonObject["courseId"].GetString();
                System.Diagnostics.Debug.WriteLine("=============");
                System.Diagnostics.Debug.WriteLine(courseId);
                System.Diagnostics.Debug.WriteLine(coursename);
                System.Diagnostics.Debug.WriteLine("==============");
                if (coursename == courseId)
                {
                    JsonArray name = jsonObject["names"].GetArray();
                    JsonArray lats = jsonObject["latitude"].GetArray();
                    JsonArray lngs = jsonObject["longtitude"].GetArray();
                    System.Diagnostics.Debug.WriteLine("=============");
                    System.Diagnostics.Debug.WriteLine(courseId);
                    System.Diagnostics.Debug.WriteLine("==============");
                    for (int i = 0; i < name.Count; i++)
                    {
                        List<BasicGeoposition> positions = new List<BasicGeoposition>();
                        double lat = Convert.ToDouble(lats[i].GetString());
                        double lng = Convert.ToDouble(lngs[i].GetString());
                        positions.Add(new BasicGeoposition() { Latitude = lat, Longitude = lng });
                        MapIcon icon = new MapIcon();
                        icon.Title = name[i].GetString();
                        icon.Location = new Geopoint(positions.ElementAt<BasicGeoposition>(0));
                        icon.NormalizedAnchorPoint = new Point(0.5, 0.5);
                        myMap.MapElements.Add(icon);
                    }
                }

            }
        }
        private async void ShowMyLocationOnTheMap()
        {
            getData();

            Geolocator myGeolocator = new Geolocator();
            myGeolocator.DesiredAccuracyInMeters = 50;
            double lat = 0;
            double lng = 0;
            //get current location
            try
            {
                Geoposition geoposition = await myGeolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10));
                lat = geoposition.Coordinate.Latitude;
                lng = geoposition.Coordinate.Longitude;
                //latTxt.Text = geoposition.Coordinate.Latitude.ToString("0.00");
                //lngTxt.Text = geoposition.Coordinate.Longitude.ToString("0.00");
            }
            catch (UnauthorizedAccessException)
            {
                //latTxt.Text = "eieieie";
            }
            myMap.Center = new Geopoint(new BasicGeoposition(){ Latitude = lat, Longitude = lng });
            myMap.ZoomLevel = 15;

            MapIcon icon = new MapIcon();
            icon.Title = "Me";
            icon.Location = new Geopoint(new BasicGeoposition(){Latitude = lat, Longitude = lng});
            icon.NormalizedAnchorPoint = new Point(0.5, 0.5);
            icon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Circle.png"));
            myMap.LandmarksVisible = true;
            myMap.MapElements.Add(icon);
            //Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            //Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            //GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

            //// Make my current location the center of the Map.
            //this.mapWithMyLocation.Center = myGeoCoordinate;
            //this.mapWithMyLocation.ZoomLevel = 13;
        }

        private void my_location_Click(object sender, RoutedEventArgs e)
        {
            ShowMyLocationOnTheMap();
        }
    }
}
