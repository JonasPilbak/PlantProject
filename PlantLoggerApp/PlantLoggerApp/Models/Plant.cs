﻿using System;
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
            set
            {


                if (TempWarning == "yes")
                {
                    colorBackground = Color.Red;
                }
                else
                {
                    colorBackground = Color.Default;
                }

                OnPropertyChanged();
            }

        }

       
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

        public byte[] picture;



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
            set {


                if (PlantID =="1" || PlantID =="2")
                {
                    imageSource = "SmallPlant.jpg";
                }
                else if(PlantID =="3")
                {
                    imageSource = "Small_plant.jpg";
                }else 
                {

                    imageSource = "randomPlant.jpg";
                }
                
                OnPropertyChanged(); }
               
        }

        public string temperature;

        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; OnPropertyChanged(); }
        }

        public string airHumidity;

        public string AirHumidity
        {
            get { return airHumidity; }
            set { airHumidity = value; OnPropertyChanged(); }
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
      
        public string measureId;

        public string MeasureId
        {
            get { return measureId; }
            set { measureId = value; }
        }


        public string plantID;

        public string PlantID
        {
            get { return plantID; }
            set { plantID = value; OnPropertyChanged(); }
        }

        public string dateTime;

        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }


        public Plant()
        {


        }
        public Plant(string name)
        {
            this.Name = name;

        }


        
        public Plant(string plantID, string temperature, string airHumidity, string tempWarning, string drySoil, string dateTime, ImageSource imageSource, Color colorBackground ) 
        {
            
            this.PlantID = plantID;
            this.Temperature = temperature;
            this.AirHumidity = airHumidity;
            this.TempWarning = tempWarning;
            this.DrySoil = drySoil;
            this.DateTime = dateTime;
            this.ImageSource = imageSource;
            this.ColorBackground = colorBackground;
       
        }
        
    }
}
