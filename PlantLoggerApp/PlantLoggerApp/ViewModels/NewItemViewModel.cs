﻿using PlantLoggerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string type;
        private bool temperature_warning;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
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
                Temperature_warning = Temperature_warning

            };

            await DataStore.AddItemAsync(newPlant);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}