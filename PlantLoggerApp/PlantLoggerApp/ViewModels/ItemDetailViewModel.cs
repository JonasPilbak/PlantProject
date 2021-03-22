using PlantLoggerApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    [QueryProperty(nameof(PlantID), nameof(PlantID))]
    public class ItemDetailViewModel : BaseViewModel
    {
       

        private string plantID;
        private float temperature;
        private string isDry;
        private DateTime time;
        private string type;
        private float air_humidity;
        private ImageSource imageSource;
        private string tempWarning;
        // public string Id { get; set; }

        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetProperty(ref imageSource, value);
        }

        public float Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        public float Air_humidity
        {
            get => air_humidity;
            set => SetProperty(ref air_humidity, value);
        }




        public string IsDry
        {
            
            get => isDry;
            set => SetProperty(ref isDry, value);
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

        public string PlantID
        {
            get
            {
                return plantID;
            }
            set
            {
                plantID = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string plantID)
        {
            try
            {
                
                var plant = await DataStore.GetItemAsync(plantID);
                //PlantID = plant.PlantID;
                Type = plant.type;
                TempWarning = plant.tempWarning;
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
