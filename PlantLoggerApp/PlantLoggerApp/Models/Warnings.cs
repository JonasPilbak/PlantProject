using System;
using System.Collections.Generic;
using System.Text;

namespace PlantLoggerApp.Models
{
    public class Warnings
    {
        private bool temperature_warning;

        public bool Temperature_warning
        {
            get { return temperature_warning; }
            set { temperature_warning = value; }
        }

        private bool humidity_warning;

        public bool Humidity_warning
        {
            get { return humidity_warning; }
            set { humidity_warning = value; }
        }




    }
}
