using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
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
    public sealed partial class ToDoList : Page
    {
        public ToDoList()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public int count;
        public List<importanttask> mytask = new List<importanttask>();

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {
                await deserializeJsonAsync();
                if (mytask.Count > 0)
                {
                    if (mytask.ElementAt(0).taskphase != " ⚪ add task" && mytask.ElementAt(0).taskphase != null)
                {
                    box1.Text = mytask.ElementAt(0).taskphase;
                    box1.Visibility = Visibility.Visible;
                }
                if (mytask.ElementAt(1).taskphase != " ⚪ add task" && mytask.ElementAt(1).taskphase != null)
                {
                    box2.Text = mytask.ElementAt(1).taskphase;
                    box2.Visibility = Visibility.Visible;
                }
                if (mytask.ElementAt(2).taskphase != " ⚪ add task" && mytask.ElementAt(2).taskphase != null)
                {
                    box3.Text = mytask.ElementAt(2).taskphase;
                    box3.Visibility = Visibility.Visible;
                }
                if (mytask.ElementAt(3).taskphase != " ⚪ add task" && mytask.ElementAt(3).taskphase != null)
                {
                    box4.Text = mytask.ElementAt(3).taskphase;
                    box4.Visibility = Visibility.Visible;
                }
                if (mytask.ElementAt(4).taskphase != " ⚪ add task" && mytask.ElementAt(4).taskphase != null)
                {
                    box5.Text = mytask.ElementAt(4).taskphase;
                    box5.Visibility = Visibility.Visible;
                }
                
                }

            
            
            }
            catch (FileNotFoundException)
            {

            }
            catch (ArgumentOutOfRangeException) { }
            catch (ArgumentException) { }


                // TODO: If your application contains multiple pages, ensure that you are
                // handling the hardware Back button by registering for the
                // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
                // If you are using the NavigationHelper provided by some templates,
                // this event is handled for you.
        }

        private void box1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            
            
            
            

          
            
        }

        private void addtaskbutton_Click(object sender, RoutedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            box1.Visibility = Visibility.Visible;
            check1.Visibility = Visibility.Visible;
            datetask1.Visibility = Visibility.Visible;

            if (count == 1)
            {
                box2.Visibility = Visibility.Visible;
                check2.Visibility = Visibility.Visible;
                datetask2.Visibility = Visibility.Visible;

            }
            if (count == 2)
            {
                box2.Visibility = Visibility.Visible;
                box3.Visibility = Visibility.Visible;
                check2.Visibility = Visibility.Visible;
                check3.Visibility = Visibility.Visible;
                datetask2.Visibility = Visibility.Visible;
                datetask3.Visibility = Visibility.Visible;
            }
            if (count == 3)
            {
                box2.Visibility = Visibility.Visible;
                box3.Visibility = Visibility.Visible;
                box4.Visibility = Visibility.Visible;
                check2.Visibility = Visibility.Visible;
                check3.Visibility = Visibility.Visible;
                check4.Visibility = Visibility.Visible;
                datetask2.Visibility = Visibility.Visible;
                datetask3.Visibility = Visibility.Visible;
                datetask4.Visibility = Visibility.Visible;

            }
            if (count == 4)
            {
                box2.Visibility = Visibility.Visible;
                box3.Visibility = Visibility.Visible;
                box4.Visibility = Visibility.Visible;
                box5.Visibility = Visibility.Visible;
                check2.Visibility = Visibility.Visible;
                check3.Visibility = Visibility.Visible;
                check4.Visibility = Visibility.Visible;
                check5.Visibility = Visibility.Visible;
                datetask2.Visibility = Visibility.Visible;
                datetask3.Visibility = Visibility.Visible;
                datetask4.Visibility = Visibility.Visible;
                datetask5.Visibility = Visibility.Visible;


            }
            if (count == 5)
            {
                count = 0;
            }
            count += 1;
        }

        private void date_change(object sender, DatePickerValueChangedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            DateTimeOffset date = datetask1.Date;
            TimeSpan dateDiff = date.Subtract(DateTime.Now);
            int dateleft = dateDiff.Days +1;
            
            dayleft1.Text = dateleft.ToString() + " days";
            
        }

       

        private void date_change2(object sender, DatePickerValueChangedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            DateTimeOffset date = datetask2.Date;
            TimeSpan dateDiff = date.Subtract(DateTime.Now);
            int dateleft = dateDiff.Days + 1;

            dayleft2.Text = dateleft.ToString() + " days";
        }

        private void date_change3(object sender, DatePickerValueChangedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            DateTimeOffset date = datetask3.Date;
            TimeSpan dateDiff = date.Subtract(DateTime.Now);
            int dateleft = dateDiff.Days + 1;

            dayleft3.Text = dateleft.ToString() + " days";

        }

        private void date_change4(object sender, DatePickerValueChangedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            DateTimeOffset date = datetask4.Date;
            TimeSpan dateDiff = date.Subtract(DateTime.Now);
            int dateleft = dateDiff.Days + 1;

            dayleft4.Text = dateleft.ToString() + " days";

        }

        private void date_change5(object sender, DatePickerValueChangedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
            DateTimeOffset date = datetask5.Date;
            TimeSpan dateDiff = date.Subtract(DateTime.Now);
            int dateleft = dateDiff.Days + 1;

            dayleft5.Text = dateleft.ToString() + " days";

        }
        private const string JSONFILENAME = "data.json";

        private List<importanttask> buildObjectGraph()
        {
            var mytask = new List<importanttask>();

            mytask.Add(new importanttask() { taskphase = box1.Text });
            mytask.Add(new importanttask() { taskphase = box2.Text });
            mytask.Add(new importanttask() { taskphase = box3.Text });
            mytask.Add(new importanttask() { taskphase = box4.Text });
            mytask.Add(new importanttask() { taskphase = box5.Text });
            
            return mytask;
        }

        

        private async Task writeJsonAsync()
        {
            // notice that the write is ALMOST identical to XML except only the serializer
            var mytask = buildObjectGraph();

            var serializer = new DataContractJsonSerializer(typeof(List<importanttask>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(JSONFILENAME, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, mytask);
            }
        }

        private async Task readJsonAsync()
        {
            string content = String.Empty;

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
            }
        }

        private async Task deserializeJsonAsync()
        {
            string content = string.Empty;
            

            var jsonSerializer = new DataContractJsonSerializer(typeof(List<importanttask>));

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);

            mytask = (List<importanttask>)jsonSerializer.ReadObject(myStream);

            foreach (var importanttask in mytask)
            {
              
            }

        }

        private async void savetask_click(object sender, RoutedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.White);
            await writeJsonAsync(); 
        }


        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HubPage));
        }

        private void text_edit(object sender, TextChangedEventArgs e)
        {
            savedtask.Foreground = new SolidColorBrush(Colors.DeepSkyBlue);
        }

    }
}
