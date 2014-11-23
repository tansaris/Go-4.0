using Resource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
    public sealed partial class Resource : Page
    {
        public string filePath = "";
        public string courseID;
        public int position;
        List<ResourceData> myData = new List<ResourceData>();
        public Resource()
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
            courseID = e.Parameter.ToString();
            //try
            //{
                await deserializeJsonAsync();
           // }
            //catch(FileNotFoundException)
           // {}
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            

            
            //resourceGrid.Width = 250;
            //resourceGrid.Height = 100;
            //resourceGrid.HorizontalAlignment = HorizontalAlignment.Left;
            //resourceGrid.VerticalAlignment = VerticalAlignment.Top;
          

            // Define the Columns
            //int numBook = 4;
            //int numVideo = 6;
            //int numSheet = 6;
           
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            resourceGrid.ColumnDefinitions.Add(colDef1);
            resourceGrid.ColumnDefinitions.Add(colDef2);
            // Define the Rows
            JsonArray bookName = new JsonArray();
            int course_index = 0;
            int temp = 0;
            foreach (ResourceData course in myData)
            {
                if (course.CourseId == courseID)
                {
                    course_index = temp;
                    bookName = course.bookName;
                }
                temp++;
            }

            
                    //int boxNum = myData.bookName.length();
                    int boxNum = bookName.Count();
                    int colNum = 2;
                    int rowNum = boxNum / 2 + boxNum % 2;
                    
                    RowDefinition[] rowDef = new RowDefinition[rowNum];

                    for (int i = 0; i < rowNum; i++)
                    {
                        rowDef[i] = new RowDefinition();
                        resourceGrid.RowDefinitions.Add(rowDef[i]);
                    }

                    StackPanel[] stackBig = new StackPanel[boxNum];
                    StackPanel[] stack1 = new StackPanel[boxNum];
                    StackPanel[] stack2 = new StackPanel[boxNum];
                    
                    InitializeComponent();

                    for (int i = 0; i < boxNum; i++)
                    {
                        Image image = new Image();
                        image.Source = new BitmapImage(new Uri(myData.ElementAt(course_index).bookCover[i].GetString()));
                        image.Margin = new Thickness(3,10,3,3);
                        //image.Height = 260;
                        image.Width = 150;
                        
                        image.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                            TextBlock boxName = new TextBlock();
                            boxName.FontSize = 16;
                            boxName.TextAlignment = TextAlignment.Center;
                            boxName.VerticalAlignment = VerticalAlignment.Center;
                            boxName.Text = myData.ElementAt(course_index).bookName[i].GetString();
                            boxName.Foreground = new SolidColorBrush(Colors.Black);
                            boxName.FontSize = 18;

                            boxName.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
                            //boxName.TextTrimming = TextTrimming.CharacterEllipsis;
                            stack1[i] = new StackPanel();
                            SolidColorBrush tanGray = new SolidColorBrush();
                            tanGray.Color = Color.FromArgb(200, 200, 200, 200);
                            stack1[i].Background = tanGray;
                            stack1[i].Height = 250;
                            stack1[i].Width = 200;
                            stack1[i].HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                            stack1[i].VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
                            stack1[i].Children.Add(image);
                            stack2[i] = new StackPanel();
                            stack2[i].Background = new SolidColorBrush(Colors.White);
                            stack2[i].Height = 75;
                            stack2[i].Width = 200;
                            stack2[i].Children.Add(boxName);
                            stackBig[i] = new StackPanel();
                            stackBig[i].Orientation = Orientation.Vertical;
                            stackBig[i].Height = 400;
                            stackBig[i].Children.Add(stack1[i]);
                            stackBig[i].Children.Add(stack2[i]);
                            stackBig[i].Margin = new Thickness(5);
                            stackBig[i].Tag = i;
                            position = course_index;
                            stackBig[i].Tapped += resource_tab;
                            
                    }

                    int l = 0;
                    for(int k= 0; k < rowNum; k++)
                    {
                        for (int j = 0; j < colNum ; j++)
                        {
                            if (l < boxNum)
                            {
                                Grid.SetRow(stackBig[l], k);
                                Grid.SetColumn(stackBig[l], j);
                                resourceGrid.Children.Add(stackBig[l]);
                                l = l + 1;
                            }
                       }
                    }         
        }

      
       // private const string JSONFILENAME = "resources.json";
        private async Task deserializeJsonAsync()
        {

            var client1 = new HttpClient(); // Add: using System.Net.Http;
            var response1 = await client1.GetAsync(new Uri("http://tanwebsite.me/groupstudy/resource/groupStudyResource.php"));
            var jsonText1 = await response1.Content.ReadAsStringAsync();
            JsonArray jsonArray = JsonArray.Parse(jsonText1);


            foreach (JsonValue itemJson in jsonArray)
            {
                JsonObject jsonObject = itemJson.GetObject();
                myData.Add(new ResourceData()
                {
                    CourseId = jsonObject["CourseId"].GetString(),
                    title = jsonObject["title"].GetString(),
                    bookName = jsonObject["bookName"].GetArray(),
                    bookPath = jsonObject["bookPath"].GetArray(),
                    bookCover = jsonObject["bookCover"].GetArray(),
                    //videoName = jsonObject["videoName"].GetArray(),
                    //videoPath = jsonObject["videoPath"].GetArray(),
                    //videoCover = jsonObject["videoCover"].GetArray(),
                    //sheetName = jsonObject["sheetName"].GetArray(),
                    //sheetPath = jsonObject["sheetPath"].GetArray(),
                    //sheetCover = jsonObject["sheetCover"].GetArray(),
                });

            }
        }
        private async void resource_tab(object sender, TappedRoutedEventArgs e)
        {
            StackPanel temp = (StackPanel)sender;
            int i = (int)temp.Tag;
            System.Diagnostics.Debug.WriteLine("c_index:" + position);
            System.Diagnostics.Debug.WriteLine("i_index:" + i);
            filePath = myData.ElementAt(position).bookPath[i].GetString();
            //Uri HomeUri = new Uri("http://tanwebsite.me/groupstudy/resource/KreyszigSolutions.pdf");
            //webView.Navigate(HomeUri);
            //webView.Visibility = Visibility.Visible;
            //System.Diagnostics.Debug.WriteLine("eieieie");
                //Uri source = new Uri("http://tanwebsite.me/groupstudy/resource/P1080663.MOV".Trim());

            await Launcher.LaunchUriAsync(new Uri(filePath));

                // Attach progress and completion handlers.
                //HandleDownloadAsync(download, true);
            
        }


        public Window mainWindow { get; set; }

        private void back_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapOrResource), courseID);
        }


    }
}
