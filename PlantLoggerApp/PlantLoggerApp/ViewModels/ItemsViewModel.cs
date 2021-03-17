using PlantLoggerApp.Models;
using PlantLoggerApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlantLoggerApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Plant _selectedItem;


        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                SetProperty(ref imageSource, value);
            }
        }

       

       


        public Command TappedTest { get; }
        public Command AddPicture { get; }
        public ObservableCollection<Plant> Plants { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Plant> ItemTapped { get; }

        public ItemsViewModel()
        {
            
            Title = "Show plants";
            Plants = new ObservableCollection<Plant>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Plant>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            TappedTest = new Command(testMethod);
        }

        public async void testMethod() 
        {
            
            Console.WriteLine(Plants.GetType());

        }


       


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Plants.Clear();
                var plants = await DataStore.GetItemsAsync(true);
                foreach (var plant in plants)
                {
                    Plants.Add(plant);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Plant SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        

        async void OnItemSelected(Plant plant)
        {
            if (plant == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.PlantID)}={plant.PlantID}");
        }
    }
}