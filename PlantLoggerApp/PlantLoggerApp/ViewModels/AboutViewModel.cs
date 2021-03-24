using PlantLoggerApp.Models;
using Plugin.LocalNotification;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        
       
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




        public Command MakeNotification { get; }
        public Command AddPicture { get; }
        public Command FindPhoto { get; }
        public ObservableCollection<Plant> Plants { get; }

        public AboutViewModel()
        {
            Plants = new ObservableCollection<Plant>();
            Title = "Main Page";
            ThePlants = new Plant();
            MakeNotification = new Command(appNotification);
            AddPicture = new Command(takePicture);
            FindPhoto = new Command(pickPhoto);



            
        }

        private async void appNotification() 
        {

           // CrossLocalNotifications.Current.Show("This is a test", "Ok");
        
        }
        private async void pickPhoto()
        {

            
            Plant testPlant = new Plant();
            Console.WriteLine("This is the pick photo");
         

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions

            {
                Title = "Please pick a photo"
                
            });
            var stream = await result.OpenReadAsync();

            testPlant.ImageSource = ImageSource.FromStream(() => stream);

            ThePlants = testPlant;

            
            Console.WriteLine(thePlants.ToString() + "This is the console");

        

           
            


        }




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

       
    }
}