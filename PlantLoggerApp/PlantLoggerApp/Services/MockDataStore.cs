using Newtonsoft.Json;
using PlantLoggerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlantLoggerApp.Services
{
    public class MockDataStore : IDataStore<Plant>
    {
       
        public List<Plant> plants;

        public MockDataStore()
        {
            


            plants = new List<Plant>()
            
            {

               // new Plant { PlantID = "1", Type = "First item", Temperature_warning=false , Temperature = 5, Air_humidity = 1, IsDry = false }
              /*
                new Plant { PlantID = Guid.NewGuid().ToString(), Type = "Second item", Temperature_warning=false },
                new Plant { PlantID = Guid.NewGuid().ToString(), Type = "Third item", Temperature_warning= false },
                new Plant { PlantID = Guid.NewGuid().ToString(), Type = "Fourth item", Temperature_warning=false },
                new Plant { PlantID = Guid.NewGuid().ToString(), Type = "Fifth item", Temperature_warning= false },
                new Plant { PlantID = Guid.NewGuid().ToString(), Type = "Sixth item", Temperature_warning= false}
               */
                

            };
          



        }

      
        



        public async Task<bool> AddItemAsync(Plant plant)
        {
            plants.Add(plant);
            //postRequest();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Plant plant)
        {
            var oldItem = plants.Where((Plant arg) => arg.PlantID == plant.plantID).FirstOrDefault();
            plants.Remove(oldItem);
            plants.Add(plant);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string plantID)
        {
            var oldItem = plants.Where((Plant arg) => arg.PlantID == plantID).FirstOrDefault();
            plants.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Plant> GetItemAsync(string plantID)
        {
            return await Task.FromResult(plants.FirstOrDefault(s => s.PlantID == plantID));
        }

        public async Task<IEnumerable<Plant>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(plants);
        }
    }
}