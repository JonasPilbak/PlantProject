using Newtonsoft.Json;
using PlantLoggerApp.Models;
using PlantLoggerApp.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public class NewItemViewModel : BaseViewModel , IFileService
    {
       
      
        private Plant thePlants = null;

        public Plant ThePlants
        {
            get => thePlants;
            set => SetProperty(ref thePlants, value);
        }

        private string airHumidity;
        private string name;
        private string plantID;
        private string temperature;
        private string drySoil;
        private string type;
       // private string type;
       // private byte[] pictures;
      //  private string air_humidity;
       // private ImageSource ImageSource;
        private string tempWarning;
        public string dateTime;
      
/*
        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetProperty(ref imageSource, value);
        }

        */
      


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

           
            /*
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });

                if (photo != null)
                    testPlant.ImageSource = ImageSource.FromStream(() => { return photo.GetStream(); });

            }
            catch (Exception ex)
            {
               
            }
           
            */
            
            
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
            /*
            Plant testPlant = new Plant();

            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });

                if (photo != null)
                    testPlant.ImageSource = ImageSource.FromStream(() => { return photo.GetStream(); });

            }
            catch (Exception ex)
            {
                
            }
        
            */
    







    
    Plant testPlant = new Plant();
    Console.WriteLine("This is the take photo");

    FileResult result = await MediaPicker.CapturePhotoAsync();


    Stream stream = await result.OpenReadAsync();

    testPlant.ImageSource = ImageSource.FromStream(() => stream);


    
    ThePlants = testPlant;

    // string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Images", "temp");
    // testPlant.imageSource = folderPath;

    // Directory.CreateDirectory(folderPath);

    //  File.WriteAllBytes(folderPath,)
    // string fileName = URL.ToString().Split('/').Last();
    //string filePath = System.IO.Path.Combine(folderPath, fileName);





    // var test = testPlant.Picture;

    // Console.WriteLine(testPlant.ToString() + "This is the console");
    //Plants.Add(thePlants);


    // plants.Add(ThePlants);




    //Console.WriteLine(thePlants.ToString() + "This is the console");
}


        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string AirHumidity
        {
            get => airHumidity;
            set => SetProperty(ref airHumidity, value);
        }


        public string PlantID
        {
            get => plantID;
            set => SetProperty(ref plantID, value);
        }



        public string Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        public string DrySoil
        {
            get => drySoil;
            set => SetProperty(ref drySoil, value);
        }

        public string DateTime
        {
            get => dateTime;
            set => SetProperty(ref dateTime, value);
        }



        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public string TempWarning
        {
            get => tempWarning;
            set => SetProperty(ref tempWarning, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public Command PostCommand { get; }


      
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }






        private async void OnSave()
        {
            Plant newPlant = new Plant()
            {
                
                plantID = PlantID,
                Temperature = temperature,
                AirHumidity = AirHumidity,
                tempWarning = TempWarning,
                drySoil = DrySoil,
                dateTime = DateTime,
               
               // Air_humidity = Air_humidity,
               // Temperature = Temperature,
                //ImageSource = ThePlants.ImageSource,
                


            };

            

           

         
            
                await DataStore.AddItemAsync(newPlant);
            
            var json = JsonConvert.SerializeObject(newPlant);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://192.168.87.171:3000/plants";
            var client = new HttpClient();
            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            
            
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public void SavePicture(string name, Stream data, string location = "temp")
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            documentsPath = Path.Combine(documentsPath, "Orders", location);
            Directory.CreateDirectory(documentsPath);

            string filePath = Path.Combine(documentsPath, name);

            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (data)
                {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);
            }
        }
    }
}
