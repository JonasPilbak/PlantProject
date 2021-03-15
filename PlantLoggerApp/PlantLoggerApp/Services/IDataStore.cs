using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantLoggerApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T plant);
        Task<bool> UpdateItemAsync(T plant);
        Task<bool> DeleteItemAsync(string plantID);
        Task<T> GetItemAsync(string plantID);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
