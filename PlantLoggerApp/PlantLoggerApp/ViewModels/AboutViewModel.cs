using PlantLoggerApp.Models;
using PlantLoggerApp.Services;
using Plugin.LocalNotification;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace PlantLoggerApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        INotificationManager notificationManager;
        int notificationNumber = 0;
       // StackLayout clocklayout;
        private Plant thePlants = null;

        public Plant ThePlants
        {
            get { return thePlants; }
            set { thePlants = value; OnPropertyChanged(); }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

       // public StackLayout Clocklayout
      //  {
       //     get { return clocklayout; }
       //     set { clocklayout = value; }
       // }




        public Command MakeNotification { get; }
        public Command OnScheduleClick { get; }
        public Command AddPicture { get; }
        public Command OnSendClick { get; }


        public Command FindPhoto { get; }
        public ObservableCollection<Plant> Plants { get; }
        public ImageSource Image { get; private set; }
        public string Text { get; private set; }

        public AboutViewModel()
        {
            Plants = new ObservableCollection<Plant>();
            Title = "Main Page";
            ThePlants = new Plant();
            MakeNotification = new Command(ShowNotification);
            //AddPicture = new Command(takePicture);
            FindPhoto = new Command(pickPhoto);
            //OnScheduleClick = new Command(OnSchedule);
           // OnSendClick = new Command(Onsend);

/*
            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification();
            };
*/
        }
        /*
        public async void Onsend()
        {
            notificationNumber++;
            string title = $"Local Notification #{notificationNumber}";
            string message = $"You have now received {notificationNumber} notifications!";
            notificationManager.SendNotification("Title", "Message");
        }

        public async void OnSchedule()
        {
            notificationNumber++;
            string title = $"Local Notification #{notificationNumber}";
            string message = $"You have now received {notificationNumber} notifications!";
            notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
        }


        */
        private async void appNotification()
        {

            // CrossLocalNotifications.Current.Show("This is a test", "Ok");

        }
        private async void pickPhoto()
        {


            /*
            try
            {
                var result = await FilePicker.PickAsync();
                if (result != null)
                {
                    Text = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        Image = ImageSource.FromStream(() => stream);
                    }
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
            */



            Plant testPlant = new Plant();
            Console.WriteLine("This is the pick photo");


            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions

            {
                Title = "Please pick a photo"

            });
            var stream = await result.OpenReadAsync();

            testPlant.ImageSource = ImageSource.FromStream(() => stream);

            ThePlants = testPlant;
            Plants.Add(ThePlants);

            Console.WriteLine(thePlants.ToString() + "This is the console");







        }



        public async void ShowNotification()
        {
            /*
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: This is the title\nMessage: I am the message"
                };
                clocklayout.Children.Add(msg);
            });
            */
        }


    }
    /*
        private async void takePicture()
        {
            Plant testPlant = new Plant();
            Console.WriteLine("This is the take photo");


            FileResult result = await MediaPicker.CapturePhotoAsync();



            Stream stream = await result.OpenReadAsync();



            testPlant.ImageSource = ImageSource.FromStream(() => stream);
            ThePlants = testPlant;
            Console.WriteLine(testPlant.ToString() + "This is the console");
            //Plants.Add(thePlants);





        }

       */
}
    
