using Newtonsoft.Json;
using PlantLoggerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        readonly List<Plant> plants;
      
        private Plant thePlants = null;

        public Plant ThePlants
        {
            get => thePlants;
            set => SetProperty(ref thePlants, value);
        }



        private string plantID;
        private float temperature;
        private bool isDry;
        private DateTime time;
        private string type;
        private float air_humidity;
        //private ImageSource imageSource;
        private bool temperature_warning;
        private Color colorBackground;
        //public Color ColorBackground { get; set; } = Color.FromHex("#E40000");
/*
        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetProperty(ref imageSource, value);
        }

        */
        public Color ColorBackground
        {
            get => colorBackground;
            set => SetProperty(ref colorBackground, value);
        }

      


        public Command AddPicture { get; }
        public Command FindPhoto { get; }

        public NewItemViewModel()
        {
            AddPicture = new Command(takePicture);
            FindPhoto = new Command(pickPhoto);
            this.ThePlants = App.plant;

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

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
           // using (var memorystreamhandler = new MemoryStream()) {
                

            ThePlants = testPlant;
             //   ThePlants.ImageSource = memorystreamhandler.ToArray();
           // Console.WriteLine(thePlants.ToString() + "This is the console");
          //  }
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


           // plants.Add(ThePlants);




        //Console.WriteLine(thePlants.ToString() + "This is the console");
        }




        public string PlantID
        {
            get => plantID;
            set => SetProperty(ref plantID, value);
        }

        public float Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        public bool IsDry
        {
            get => isDry;
            set => SetProperty(ref isDry, value);
        }

        public float Air_humidity
        {
            get => air_humidity;
            set => SetProperty(ref air_humidity, value);
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public bool Temperature_warning
        {
            get => temperature_warning;
            set => SetProperty(ref temperature_warning, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public Command PostCommand { get; }


        public async void postRequest()
        {

            

           




        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }






        private async void OnSave()
        {
            Plant newPlant = new Plant()
            {
                PlantID = Guid.NewGuid().ToString(),
                Type = Type,
                Temperature_warning = Temperature_warning,
                IsDry = IsDry,
                Air_humidity = Air_humidity,
                Temperature = Temperature,
                ImageSource = ThePlants.ImageSource,
                


            };

           
           

            await DataStore.AddItemAsync(newPlant);

            /*
            var json = JsonConvert.SerializeObject(newPlant);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://httpbin.org/post";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            */
            
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

     
    }
}
