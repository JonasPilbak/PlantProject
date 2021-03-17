using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PlantLoggerApp.Models
{
    public class Plant : BindableObject
    {
        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public Color colorBackground;

        public Color ColorBackground
        {
            get { return colorBackground; }
            set { colorBackground = value; OnPropertyChanged(); }
        }

/*
        public Warnings Humidity_warning
        {
            get { return humidity_warning; }
            set { humidity_warning = value; OnPropertyChanged(); }
        }

        */
        public string type;

        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }

        
        public bool temperature_warning;

        public bool Temperature_warning
        {
            get { return temperature_warning; }
            set { temperature_warning = value; OnPropertyChanged(); }
        }

        public bool humidity_warning;

        public bool Humidity_warning
        {
            get { return humidity_warning; }
            set { humidity_warning = value; OnPropertyChanged(); }
        }

        public ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; OnPropertyChanged(); }
        }

        public bool isDry;

        public bool IsDry
        {
            get { return isDry; }
            set { isDry = value; OnPropertyChanged(); }
        }

        public DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        public float air_humidity;

        public float Air_humidity
        {
            get { return air_humidity; }
            set { air_humidity = value; OnPropertyChanged(); }
        }

        public string plantID;

        public string PlantID
        {
            get { return plantID; }
            set { plantID = value; OnPropertyChanged(); }
        }



    }
}
