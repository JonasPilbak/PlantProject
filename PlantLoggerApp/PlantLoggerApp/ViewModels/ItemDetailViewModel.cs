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
        private bool isDry;
        private DateTime time;
        private string type;
        private float air_humidity;
        private ImageSource imageSource;
        private bool temperature_warning;
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




        public bool IsDry
        {
            
            get => isDry;
            set => SetProperty(ref isDry, value);
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
                PlantID = plant.PlantID;
                Type = plant.type;
                Temperature_warning = plant.temperature_warning;
                Temperature = plant.temperature;
                ImageSource = plant.imageSource;
                
                IsDry = plant.isDry;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
