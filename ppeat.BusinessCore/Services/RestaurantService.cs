using Microsoft.EntityFrameworkCore;
using ppeat.BusinessCore.Contracts;
using ppeat.DataAccess.Data;
using ppeat.Domain.Enums;
using ppeat.Domain.Models;

namespace ppeat.BusinessCore.Services;

public class RestaurantService : IRestaurantService
{
    private readonly ApplicationDbContext _context;
    private readonly IFileService _fileService;

    public RestaurantService(ApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<List<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> GetRestaurantWithHighestRatingAsync()
    {
        return await _context.Restaurants
            .Include(r => r.Comments)
            .OrderByDescending(r => r.Comments.Average(c => c.Rating))
            .FirstOrDefaultAsync();
    }

    public async Task<Restaurant?> GetRestaurantWithHighestOccupancyAsync()
    {
        return await _context.Restaurants
            .Include(r => r.Reservations)
            .OrderByDescending(r => r.Reservations.Sum(res => res.PersonCount))
            .FirstOrDefaultAsync();
    }

    public async Task<string> UploadRestaurantImageAsync(Guid restaurantId, Stream file, string fileName)
    {
        var imageUrl = await _fileService.UploadFile(file, fileName);
        var restaurant = await _context.Restaurants.FindAsync(restaurantId);
        if (restaurant != null)
        {
            restaurant.ImageUrl = imageUrl;
            await _context.SaveChangesAsync();
        }
        return imageUrl;
    }

    public async Task<Restaurant> IncludeRestaurantAsync(string name, string location, int tableCount, Cuisine cuisine)
    {
        var restaurant = new Restaurant
        {
            Name = name,
            Location = location,
            AvailableTableCount = tableCount,
            Cuisine = cuisine,
            CreatedDate = DateTime.UtcNow,
            ChangedDate = DateTime.UtcNow
        };

        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
        return restaurant;
    }

    public async Task UpdateRestaurantLocationAsync(Guid restaurantId, string location)
    {
        var restaurant = await _context.Restaurants.FindAsync(restaurantId);
        if (restaurant != null)
        {
            restaurant.Location = location;
            restaurant.ChangedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateRestaurantInventoryAsync(Guid restaurantId, int tableCount)
    {
        var restaurant = await _context.Restaurants.FindAsync(restaurantId);
        if (restaurant != null)
        {
            restaurant.AvailableTableCount = tableCount;
            restaurant.ChangedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task MarkRestaurantAsClosedAsync(Guid restaurantId)
    {
        var restaurant = await _context.Restaurants.FindAsync(restaurantId);
        if (restaurant != null)
        {
            restaurant.IsClosed = true; // Assuming there's an IsClosed property
            restaurant.ChangedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}