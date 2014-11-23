using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.System.Display;
using Windows.UI.Core;
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
    
    public sealed partial class Gyro : Page
    {
        // Attribute
        Accelerometer myAccelerometer;
        DateTime lastTime, startTime;
        DispatcherTimer timer = new DispatcherTimer();
        public bool boo;
        public List<Record> myData = new List<Record>();
        public Gyro()
        {

            this.InitializeComponent();


            //Constructor
            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            //Clock Hiding
            ClockXaml.Visibility = Visibility.Collapsed;
        }

        public void ShowQuote()
        {
            Random rnd = new Random();
            int quoternd = rnd.Next(1, 10);

            switch (quoternd)
            {
                case 1:
                    QuoteBlock.Text = "Live as if you were to die tomorrow. Learn as if you were to live forever. \n -Mahatma Gandhi";
                    break;
                case 2:
                    QuoteBlock.Text = "I have never let my schooling interfere with my education. \n -Mark Twain";
                    break;
                case 3:
                    QuoteBlock.Text = "You can never be overdressed or overeducated. \n -Oscar Wilde";
                    break;
                case 4:
                    QuoteBlock.Text = "You educate a man; you educate a man. You educate a woman; you educate a generation. \n -Brigham Young";
                    break;
                case 5:
                    QuoteBlock.Text = "The world is a book and those who do not travel read only one page. \n -Augustine of Hippo";
                    break;
                case 6:
                    QuoteBlock.Text = "Education is the most powerful weapon which you can use to change the world. \n -Nelson Mandela";
                    break;
                case 7:
                    QuoteBlock.Text = "Education is the ability to listen to almost anything without losing your temper or your self-confidence. \n -Robert Frost";
                    break;
                case 8:
                    QuoteBlock.Text = "Whatever the cost of our libraries, the price is cheap compared to that of an ignorant nation. \n -Walter Cronkite";
                    break;
                case 9:
                    QuoteBlock.Text = "The past has no power over the present moment. \n -Eckhart Tolle";
                    break;
                case 10:
                    QuoteBlock.Text = "Education: the path from cocky ignorance to miserable uncertainty.. \n -Mark Twain";
                    break;

            }

        }





        //For Timer


        void timer_Tick(object sender, object e)
        {
            secondHand.Angle = DateTime.Now.Second * 6;
            minuteHand.Angle = DateTime.Now.Minute * 6;
            hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            myAccelerometer = Accelerometer.GetDefault();
            //Disable Landscape
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
            //Invisible Clock
            image1.Visibility = Visibility.Collapsed;
            await deserializeJsonAsync();
            
            if(myData != null){
                if(myData.Count != 0){
                    TimeSpan best = myData.ElementAt(0).time;
                    string show = "";
                    if (best.TotalSeconds > 60 && best.TotalSeconds < 3600)
                    {
                        show += "Your Best Reading Time : " + best.Minutes + " minutes " + best.Seconds + " seconds" + "\n";
                    }
                    else if (best.TotalSeconds >= 3600)
                    {
                        show += "Your Best Reading Time : " + best.Hours + " hours " + best.Minutes + " minutes " + best.Seconds + " seconds" + "\n";
                    }
                    else if (best.TotalSeconds > 3 && best.TotalSeconds <= 60)
                    {
                        show += "Your Best Reading Time: " + best.Seconds + " seconds" + "\n";
                    }
                    recordBlock.Text = show;
                }
            }
            
            

        }
        public void OnTimerTick(object sender, EventArgs e)
        {
            //Textblock1.Text = DateTime.Now.ToString();
        }
        private async void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            //Lap Stopper
            boo = true;
            //Button Disabler
            buttonStart.IsEnabled = false;
            //Accel
            myAccelerometer = Accelerometer.GetDefault();
            if (myAccelerometer != null)
            {
                // Select a report interval that is both suitable for the purposes of the app and supported by the sensor.
                // This value will be used later to activate the sensor.
                uint minReportInterval = myAccelerometer.MinimumReportInterval;
                uint desiredReportInterval = minReportInterval > 16 ? minReportInterval : 16;
                myAccelerometer.ReportInterval = desiredReportInterval;
                //add event for accelerometer readings
                myAccelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(myAccelerometer_ReadingChanged);
            }
            else
            {
                MessageDialog ms = new MessageDialog("No accelerometer Found");
                await ms.ShowAsync();
            }
            //For Accelerometer
            //myAccelerometer.Start();
            //myAccelerometer.ReadingChanged += myAccelerometer_ReadingChanged;
            //For Timer
            DispatcherTimer newTimer = new DispatcherTimer();
            newTimer.Interval = TimeSpan.FromSeconds(1);
            //newTimer.Tick += OnTimerTick;
            newTimer.Start();
            lastTime = DateTime.Now;
            startTime = DateTime.Now;
            Textblock3.Text = "Start time : " + lastTime.ToString() + "\n";
            //For Text
            lblTimer.Text = "";
            lblTimer.FontSize = 24;
            Notice1.Visibility = Visibility.Collapsed;
            Notice2.Visibility = Visibility.Collapsed;
            Textblock3.Visibility = Visibility.Visible;
            Textblock4.Visibility = Visibility.Visible;
            //For Clock
            ClockXaml.Visibility = Visibility.Visible;
            //For Clock BG
            image1.Visibility = Visibility.Visible;


        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HubPage));




        }
        private void PlaySound()
        {
            try
            {
                sound.Play();
                //if (!string.IsNullOrEmpty(path))
                //{
                //    using (var stream = TitleContainer.OpenStream(path))
                //    {
                //        if (stream != null)
                //        {
                //            var effect = SoundEffect.FromStream(stream);
                //            FrameworkDispatcher.Update();
                //            effect.Play();
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

            }
        }
        public async void myAccelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                
                AccelerometerReading reading = e.Reading;
                //System.Diagnostics.Debug.WriteLine("x:" + reading.AccelerationX.ToString());
                //System.Diagnostics.Debug.WriteLine("y:" + reading.AccelerationY.ToString());
                //System.Diagnostics.Debug.WriteLine("z:" + reading.AccelerationZ.ToString());

                if (reading.AccelerationX > 0.2 || reading.AccelerationY > 0.2 || reading.AccelerationZ > 0 || reading.AccelerationX <-0.4 || reading.AccelerationY <-0.4)
                {
                    //For Accelerometer
                    myAccelerometer = null;
                    if (boo)
                    {
                        //For Timer
                        DateTime endTime = DateTime.Now;
                        TimeSpan span = endTime.Subtract(startTime);

                        //FOR CONVERTING SECONDS TO OTHERS
                        TimeSpan t = TimeSpan.FromSeconds(span.TotalSeconds);
                        Record old_best = new Record()
                        {
                            time = new TimeSpan(0)
                        };
                        if (myData != null)
                        {
                            if (myData.Count != 0)
                            {
                                old_best = myData.ElementAt(0);
                            }
                        }
                        System.Diagnostics.Debug.WriteLine("========");
                        System.Diagnostics.Debug.WriteLine(old_best.time.TotalSeconds.ToString());
                        System.Diagnostics.Debug.WriteLine(span.TotalSeconds.ToString());
                        if (old_best.time.TotalSeconds < span.TotalSeconds)
                        {
                           buildObjectGraph(span);
                            //FOR RECORD BEST
                           string show = "";
                           if (span.TotalSeconds > 60 && span.TotalSeconds < 3600)
                           {
                               show += "Your Best Reading Time : " + span.Minutes + " minutes " + span.Seconds + " seconds" + "\n";
                           }
                           else if (span.TotalSeconds >= 3600)
                           {
                               show += "Your Best Reading Time : " + span.Hours + " hours " + span.Minutes + " minutes " + span.Seconds + " seconds" + "\n";
                           }
                           else if (span.TotalSeconds > 3 && span.TotalSeconds <= 60)
                           {
                               show += "Your Best Reading Time: " + span.Seconds + " seconds" + "\n";
                           }
                           recordBlock.Text = show;
                           var messageDialog = new MessageDialog("Congratulation!!\n You have set the new best reading time.");
                           messageDialog.ShowAsync();

                        }
                        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds,
                                        t.Milliseconds);
                        

                        if (span.TotalSeconds > 60 && span.TotalSeconds < 3600)
                        {

                            lblTimer.Text += "Your Reading Time : " + t.Minutes + " minutes " + t.Seconds + " seconds" + "\n";
                        }
                        else if (span.TotalSeconds >= 3600)
                        {
                            lblTimer.Text += "Your Reading Time : " + t.Hours + " hours " + t.Minutes + " minutes " + t.Seconds + " seconds" + "\n";
                        }
                        else if (span.TotalSeconds > 2 && span.TotalSeconds <= 60)
                        {
                            lblTimer.Text += "Your Reading Time: " + t.Seconds + " seconds" + "\n";

                        }
                        else
                        {
                            //If timer count < 2 seconds, device isn't flat enough and therefore Start, End, and Quote are not visible.
                            lblTimer.FontSize = 16;
                            lblTimer.Text = "You haven't place your device on flat surface yet. \n Try Again!";
                            QuoteBlock.Visibility = Visibility.Collapsed;
                            Textblock3.Visibility = Visibility.Collapsed;
                            Textblock4.Visibility = Visibility.Collapsed;
                            buttonStart.IsEnabled = true;
                        }

                        span = endTime.Subtract(lastTime);
                        lastTime = DateTime.Now;

                        //For Text

                        Textblock4.Text = "End time : " + lastTime.ToString() + "\n";
                        //Textblock3.Visibility = Visibility.Collapsed;
                        //Textblock2.Text = "Reading Ends!";
                        //For Sound
                        PlaySound();
                        //For Clock
                        ClockXaml.Visibility = Visibility.Collapsed;

                        
                        //Dummy UNlaptime
                        boo = false;
                        //For Quote
                        ShowQuote();
                        

                    }
                }
 
            });
            //try
            //{
                //await writeJSON();
            //}
            //catch (Exception)
            //{

            //}
            

        }
        private async Task deserializeJsonAsync()
        {
            //if (myData.Count > 0)
            //{
            try
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(List<Record>));
                var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
                myData = (List<Record>)jsonSerializer.ReadObject(myStream);
            }
            catch (Exception) { }
            //}
        }
        private void buildObjectGraph(TimeSpan input)
        {
            myData = new List<Record>();
            myData.Add(new Record(){
                time = input
            });
        }
        private const string JSONFILENAME = "time_record.json";

        private async Task writeJSON()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Record>));
            System.Diagnostics.Debug.WriteLine("WRITE");
            System.Diagnostics.Debug.WriteLine(myData.ElementAt(0).time.TotalSeconds.ToString());
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                    JSONFILENAME,
                    CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myData);
            }

        }
        protected async override void OnNavigatedFrom(NavigationEventArgs e)
        {
 	        base.OnNavigatedFrom(e);
            await writeJSON();
        }
    }
}
