using PlantLoggerApp.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantLoggerApp.Views
{
    public partial class AboutPage : ContentPage
    {


        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }


       /*
         async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            var stream = await result.OpenReadAsync();

            resultImage.Source = ImageSource.FromStream(() => stream);
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions

            {
                Title = "Please pick a photo"


            });
            var stream = await result.OpenReadAsync();

            Plant.Picture.Source = ImageSource.FromStream(() => stream);


        }
       */
    }
}