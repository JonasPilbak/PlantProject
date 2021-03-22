using System;
using System.Collections.Generic;
using System.Text;

namespace PlantLoggerApp.Services
{
    public interface Inotification
    {
        void CreateNotification(String title, String message);

    }
}
