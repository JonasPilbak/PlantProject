using PlantLoggerApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PlantLoggerApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}