using PlantLoggerApp.Models;
using PlantLoggerApp.Services;
using PlantLoggerApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantLoggerApp
{
    public partial class App : Application
    {
        public static Plant plant = new Plant();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
