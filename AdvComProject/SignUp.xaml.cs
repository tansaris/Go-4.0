﻿using AdvComProject.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AdvComProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUp : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        int numHeight;
        int pageNum = 0;
        List<UserPass> myData = new List<UserPass>();

        public SignUp()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("dkgnkldbdgkb");
            await deserializeJsonAsync();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }
        private async Task deserializeJsonAsync()
        {
            //if (myData.Count > 0)
            //{
            try
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<UserPass>));
                var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
                myData = (List<UserPass>)jsonSerializer.ReadObject(myStream);
            }
            catch (Exception) { }
            //}
        }
        private List<UserPass> buildObjectGraph()
        {
            myData.Add(new UserPass()
            {
                usernameData = userSignup.Text,
                passwordData = passSignup.Password,
                nameData = nameSignup.Text
            });
            return myData;
        }
        private const string JSONFILENAME = "data.json";

        private async Task writeJSON()
        {
            buildObjectGraph();
            var serializer = new DataContractJsonSerializer(typeof(List<UserPass>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                    JSONFILENAME,
                    CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myData);
            }

        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>


        #endregion

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private async void signup_Click(object sender, RoutedEventArgs e)
        {
            if (passSignup.Password != passSignup2.Password)
            {
                var messageDialog = new MessageDialog("Password do not match");
                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("Welcome " + nameSignup.Text + " ! Now please Login.");
                await messageDialog.ShowAsync();
                await writeJSON();
                //System.Diagnostics.Debug.WriteLine("this is number of data: !!!");
                //System.Diagnostics.Debug.WriteLine(myData.Count);
                //for (int i = 0; i < myData.Count; i++ )
                //{
                //    System.Diagnostics.Debug.WriteLine("the data number : ", i, " and the data inside is :");
                //    System.Diagnostics.Debug.WriteLine(myData.ElementAt(i).usernameData);
                //}
                Frame.Navigate(typeof(Login));

            }
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
