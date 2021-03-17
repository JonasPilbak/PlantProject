using PlantLoggerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string plantID;
        private float temperature;
        private bool isDry;
        private DateTime time;
        private string type;
        private float air_humidity;
        private Image picture;
        private bool temperature_warning;
        private Color colorBackground;
        //public Color ColorBackground { get; set; } = Color.FromHex("#E40000");

        public Color ColorBackground
        {
            get => colorBackground;
            set => SetProperty(ref colorBackground, value);
        }
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
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
                ColorBackground = ColorBackground,

            };
            if (IsDry == false)
            {
                colorBackground = Color.FromHex("#11111");
            }

            await DataStore.AddItemAsync(newPlant);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
