using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PlantLoggerApp.Models
{
    public class Plant : BindableObject
    {
        public static Plant plant = new Plant();


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

        
        public string tempWarning;

        public string TempWarning
        {
            get { return tempWarning; }
            set { tempWarning = value; OnPropertyChanged(); }
        }

        public bool humidity_warning;

        public bool Humidity_warning
        {
            get { return humidity_warning; }
            set { humidity_warning = value; OnPropertyChanged(); }
        }

        private byte[] picture;

        

        public byte[] Picture
        {
            get => picture;
            set { 
                picture = value;
                ImageSource = ImageSource.FromStream(() => new MemoryStream(picture));
            
            }
        }


        public ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public string temperature;

        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; OnPropertyChanged(); }
        }

        public string plantHumidity;

        public string PlantHumidity
        {
            get { return plantHumidity; }
            set { plantHumidity = value; OnPropertyChanged(); }
        }

        public string drySoil;

        public string DrySoil
        {
            get { return drySoil; }
            set { drySoil = value; OnPropertyChanged(); }
        }

        public string time;

        public string Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        public string air_humidity;

        public string Air_humidity
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

       public Plant() 
        {
        
        
        }
        public Plant(string name) 
        {
            this.Name = name;
        
        }
        public Plant(string name,string plantID, string plantHumidity , string tempWarning , string drySoil ) 
        {
            this.Name = name;
            this.PlantID = plantID;
            this.PlantHumidity = plantHumidity;
            this.TempWarning = tempWarning;
            this.DrySoil = drySoil;
       
        }
    }
}
