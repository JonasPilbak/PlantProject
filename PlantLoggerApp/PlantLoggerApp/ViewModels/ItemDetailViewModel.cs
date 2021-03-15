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

        private string type;
        private bool temperature_warning;
       // public string Id { get; set; }

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
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
