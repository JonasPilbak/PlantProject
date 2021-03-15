using PlantLoggerApp.Models;
using PlantLoggerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantLoggerApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Plant Plant { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}