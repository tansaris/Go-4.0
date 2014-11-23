using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class Login : Page
    {
        List<UserPass> myData = new List<UserPass>();
        public bool first = true;
        public Login()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            Storyboard1.Begin();
            Storyboard2.Begin();
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            await deserializeJsonAsync();
        }
        private const string JSONFILENAME = "data.json";


        private async Task deserializeJsonAsync()
        {

            var client1 = new HttpClient(); // Add: using System.Net.Http;
            var response1 = await client1.GetAsync(new Uri("http://tanwebsite.me/groupstudy/groupStudyLogin.php"));
            var jsonText1 = await response1.Content.ReadAsStringAsync();
            JsonArray jsonArray = JsonArray.Parse(jsonText1);

            var jsonSerializer = new DataContractJsonSerializer(typeof(List<UserPass>));
            try
            {
                var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
                myData = (List<UserPass>)jsonSerializer.ReadObject(myStream);

                
            }
            catch (FileNotFoundException)
            {

            }
            foreach (JsonValue itemJson in jsonArray)
            {
                JsonObject jsonObject = itemJson.GetObject();
                myData.Add(new UserPass()
                {
                    usernameData = jsonObject["Username"].GetString(),
                    passwordData = jsonObject["Password"].GetString(),
                    nameData = jsonObject["name"].GetString()

                });

            }


        }
        private async void checkUserPass()
        {
            Boolean checkUser = false;
            Boolean checkPass = false;
            try
            {
                await deserializeJsonAsync();
            }
            catch (Exception)
            {

            }
            
            if (myData.Count > 0)
            {

                for (int i = 0; i < myData.Count; i++)
                {
                    if ((userLogin.Text != "") && (passLogin.Password != ""))
                    {
                        if ((userLogin.Text == myData.ElementAt(i).usernameData) && (passLogin.Password == myData.ElementAt(i).passwordData))
                        {
                            checkUser = true;
                            checkPass = true;
                        }
                    }
                    //else
                    //{
                    //    var messageDialog = new MessageDialog("Enter your Username and Password.");
                    //    await messageDialog.ShowAsync();
                    //}
                }
                if ((checkUser == true) && (checkPass == true))
                {
                    var messageDialog = new MessageDialog("Log in successfully!");
                    await messageDialog.ShowAsync();
                    Frame.Navigate(typeof(HubPage));
                }
                else
                {
                    var messageDialog = new MessageDialog("Failed to log in. Please try again.");
                    await messageDialog.ShowAsync();
                }

            }
            //userLogin.Text = myData.ElementAt(0).usernameData;
            //// pageNum = myData.Count;
            //if (pageNum > 0)
            //{
            //    nameSubmitted.Text = myData.ElementAt(pageNum - 1).dataName;
            //    genderSubmitted.Text = myData.ElementAt(pageNum - 1).dataGender;
            //    heightSubmitted.Text = myData.Count.ToString();
            //}
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (first)
            {
                Storyboard3.Begin();
                first = false;
            }
            else
            {
                checkUserPass();
            }
            
            //Frame.Navigate(typeof(SignUp)); 
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUp));
        }



        //private async Task GetSampleDataAsync()
        //{

        //    //Uri dataUri = new Uri("ms-appx:///DataModel/SampleData.json");
        //    //StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
        //    //string jsonText = await FileIO.ReadTextAsync(file);


        //    var client1 = new HttpClient(); // Add: using System.Net.Http;
        //    var response1 = await client1.GetAsync(new Uri("http://tanwebsite.me/groupstudy/groupStudyLogin.php"));
        //    var jsonText1 = await response1.Content.ReadAsStringAsync();
        //    JsonObject jsonObject = JsonObject.Parse(jsonText1);
        //    JsonArray jsonArray = jsonObject["movies"].GetArray();
        //    //SampleDataGroup group1 = new SampleDataGroup();

        //}
    }
}
