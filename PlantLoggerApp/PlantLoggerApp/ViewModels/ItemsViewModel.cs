using Newtonsoft.Json;
using PlantLoggerApp.Models;
using PlantLoggerApp.Views;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlantLoggerApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Plant _selectedItem;


        public ImageSource imageResult { get; set; }






        public Command TappedTest { get; }
        public Command AddPicture { get; }
        public ObservableCollection<Plant> Plants { get; set; }
        public Command LoadItemsCommand { get; }
        public Command PickPicture { get; }
        public Command AddItemCommand { get; }
        public Command<Plant> ItemTapped { get; }

        public ItemsViewModel()
        {
            
            
            Title = "Show plants";
            Plants = new ObservableCollection<Plant>();
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            PickPicture = new Command(findaPicture);
            
            ItemTapped = new Command<Plant>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            TappedTest = new Command(testGet);
            
            
        }

        public async void makePdf() 
        {

           

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
        public async void findaPicture()
        {
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                
                PickerTitle = "Pick an image"
            });

            if (pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                imageResult = ImageSource.FromStream(() => stream);
            }


        }


        public async void testGet() 
        {
            Plants.Clear();

           // var plants = await DataStore.GetItemsAsync(true);
            var clientget = new HttpClient();
            var uri2 = "http://192.168.87.171:3000/measurements";
            try
            {

            var response2 = await clientget.GetAsync(uri2);

                if (response2.IsSuccessStatusCode)
                {

            string content = await response2.Content.ReadAsStringAsync();
            Console.WriteLine(content);
                    List<Plant> plantie = JsonConvert.DeserializeObject<List<Plant>>(content);
                    
                    foreach (var item in plantie)
            {
                        
                Plant planget = new Plant( item.plantID, item.temperature, item.airHumidity,item.tempWarning, item.drySoil, item.dateTime, item.imageSource, item.colorBackground);
                       

                Plants.Add(planget);
                    


            }
                    
                  

                }
            }
            catch (Exception)
            {

                Debug.WriteLine("Error");
            }

        }

            public async void editList() 
            {
            
            
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