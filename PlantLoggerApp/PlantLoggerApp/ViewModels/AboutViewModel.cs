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
          
            //AddPicture = new Command(takePicture);
            FindPhoto = new Command(pickPhoto);
           
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



     

    }
    
    
}
    
