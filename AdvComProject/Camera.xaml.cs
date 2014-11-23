using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Phone.UI.Input;
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
    public sealed partial class Camera : Page
    {
        public MediaCapture mediaCapture { get; set; }
        public StorageFile videoFile { get; set; }
        public Camera()
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

            await Initialize();
            //// Create MediaCapture and init
            //mediaCapture = new MediaCapture();
            //await mediaCapture.InitializeAsync();

            ////assign to Xaml CaptureElement.Source and start preview
            //capturecamera.Source = mediaCapture;
            //await mediaCapture.StartPreviewAsync();


            //assign to Xaml CaptureElement.Source and start preview


            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            //change camera parameter

            /* var zoomControl = mediaCapture.VideoDeviceController.Zoom;
             if (zoomControl != null && zoomControl.Capabilities.Supported)
             {
                 SliderZoom.IsEnabled = true;
                 SliderZoom.Maximum = zoomControl.Capabilities.Max;
                 SliderZoom.Minimum = zoomControl.Capabilities.Min;
                 SliderZoom.StepFrequency = zoomControl.Capabilities.Step;
                 SliderZoom.ValueChanged += (s, e ) => zoomControl.TrySetValue(SliderZoom.Value);
              }
             * */

        }

         public async Task<MediaCapture> Initialize(CaptureUse primaryUse = CaptureUse.Photo)
         {
             //Create MediaCapture and init
             mediaCapture = null;
             mediaCapture = new MediaCapture();
             var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
             await mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings
             {
                 VideoDeviceId = devices[1].Id
             });
             mediaCapture.VideoDeviceController.PrimaryUse = primaryUse;
             mediaCapture.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
             mediaCapture.SetRecordRotation(VideoRotation.Clockwise90Degrees);
             //assign to Xaml CaptureElement.Source and start preview
             capturecamera.Source = mediaCapture;
             await mediaCapture.StartPreviewAsync();
             //mediaCapture = new MediaCapture();
             //var devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
             //var deviceInfo = devices[0]; //grab first result
             //DeviceInformation frontCamera;
             //DeviceInformation rearCamera;
             //bool hasFrontCamera;
             //foreach (var device in devices)
             //{
             //    if (device.Name.ToLowerInvariant().Contains("front"))
             //    {
             //        deviceInfo = frontCamera = device;
             //        hasFrontCamera = true;
             //    }
             //    if (device.Name.ToLowerInvariant().Contains("back"))
             //    {
             //        rearCamera = device;
             //    }
             //}

             //var mediaSettings = new MediaCaptureInitializationSettings
             //{
             //    MediaCategory = MediaCategory.Communications,
             //    StreamingCaptureMode = StreamingCaptureMode.AudioAndVideo,
             //    VideoDeviceId = deviceInfo.Id
             //};

             //await mediaCapture.InitializeAsync(mediaSettings);

             return mediaCapture;
        
         }
        public async Task capturePhoto()
        {
            // create photo encoding properties as JPEG and set size that should be use for capturing
            var imgEncodingProperties = ImageEncodingProperties.CreateJpeg();
            imgEncodingProperties.Width = 1280;
            imgEncodingProperties.Height = 960;

            //create new unique file in the pictures library and capture photo into it

            var photoStorageFile = await KnownFolders.CameraRoll.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);
            await mediaCapture.CapturePhotoToStorageFileAsync(imgEncodingProperties, photoStorageFile);


            // var photoStorageFile = await KnownFolders.PicturesLibrary.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);
            // await mediaCapture.CapturePhotoToStorageFileAsync(imgEncodingProperties, photoStorageFile);


        }

        public async Task StartVideoRecording()
        {
            //  Create video encoding profile as MP4
            var videoEncodingProperties = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Vga);

            // create new unique file in the videos library and record video

            videoFile = await KnownFolders.VideosLibrary.CreateFileAsync("video.mp4", CreationCollisionOption.GenerateUniqueName);

            await mediaCapture.StartRecordToStorageFileAsync(videoEncodingProperties, videoFile);
        }
        public async Task StopVideoRecording()
        {
            await mediaCapture.StopRecordAsync();

            PlayBackElement.Visibility = Visibility.Visible;
            // start playback in media element
            var videoFileStream = await videoFile.OpenReadAsync();
            PlayBackElement.SetSource(videoFileStream, videoFile.ContentType);
            PlayBackElement.Play();
        }

        private async void takephoto_click(object sender, RoutedEventArgs e)
        {
            await capturePhoto();
        }

        private async void startvideo_click(object sender, RoutedEventArgs e)
        {
            await StartVideoRecording();
        }

        private async void endvideo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await StopVideoRecording();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HubPage));
        }
        private async void HardwareButtonsOnCameraHalfPressed(object sender, CameraEventArgs cameraEventArgs)
        {
            await mediaCapture.VideoDeviceController.FocusControl.FocusAsync();
        }
        private async void HardwareButtonsOnCameraPressed(object sender, CameraEventArgs cameraEventArgs)
        {
            await capturePhoto();
        }

        private async void take_photo(object sender, RoutedEventArgs e)
        {
            await capturePhoto();
        }

        private async void video_toggle(object sender, RoutedEventArgs e)
        {
            if ((string)video.Label == "Video")
            {
                video.Foreground = new SolidColorBrush(Colors.Red);
                video.Icon = new SymbolIcon(Symbol.Stop);
                video.Label = "Stop";
                await StartVideoRecording();

            }
            else
            {
                video.Icon = new SymbolIcon(Symbol.Video);
                video.Label = "Video";
                try
                {
                    await StopVideoRecording();
                }
                catch (NullReferenceException)
                {

                }
            }
            
        }
        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Release resources
            if (mediaCapture != null)
            {
                await mediaCapture.StopPreviewAsync();
                capturecamera.Source = null;
                mediaCapture.Dispose();
                mediaCapture = null;
            }
        }

        private void playback_ended(object sender, RoutedEventArgs e)
        {
            PlayBackElement.Visibility = Visibility.Collapsed;
        }
    }
}
