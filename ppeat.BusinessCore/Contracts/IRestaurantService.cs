using ppeat.Domain.Enums;
using ppeat.Domain.Models;

namespace ppeat.BusinessCore.Contracts
{
    public interface IRestaurantService
    {
        #region Query
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant?> GetRestaurantWithHighestOccupancyAsync();
        Task<Restaurant?> GetRestaurantWithHighestRatingAsync(); 
        #endregion

        #region Commands
        Task<Restaurant> IncludeRestaurantAsync(string name, string location, int tableCount, Cuisine cuisine);
        Task<string> UploadRestaurantImageAsync(Guid restaurantId, Stream file, string fileName);
        Task MarkRestaurantAsClosedAsync(Guid restaurantId);
        Task UpdateRestaurantInventoryAsync(Guid restaurantId, int tableCount);
        Task UpdateRestaurantLocationAsync(Guid restaurantId, string location); 
        #endregion
    }
}