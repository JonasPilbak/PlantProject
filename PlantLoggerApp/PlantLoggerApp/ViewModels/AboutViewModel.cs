using PlantLoggerApp.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                SetProperty(ref imageSource, value);
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }





        public Command AddPicture { get; }
        public Command FindPhoto { get; }
        public ObservableCollection<Plant> Plants { get; }

        public AboutViewModel()
        {
            Plants = new ObservableCollection<Plant>();
            Title = "Main Page";


            AddPicture = new Command(takePicture);
            FindPhoto = new Command(pickPhoto);
            
        }


        private async void pickPhoto()
        {

         

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions

            {
                Title = "Please pick a photo"
                
            });
            var stream = await result.OpenReadAsync();

            ImageSource = ImageSource.FromStream(() => stream);
            
                
        }




        private async void takePicture()
        {


           

            var result = await MediaPicker.CapturePhotoAsync();

           

            var stream = await result.OpenReadAsync();

           

            ImageSource = ImageSource.FromStream(() => stream);

           
            
            
            
        }

    }
}