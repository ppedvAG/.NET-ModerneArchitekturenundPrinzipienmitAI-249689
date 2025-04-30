using Microsoft.EntityFrameworkCore;
using ppeat.Domain.Enums;
using ppeat.Domain.Models;

namespace ppeat.DataAccess.Data
{
    public static class TestDataIds
    {
        public const int CustomerAliceId = 1;
        public const int CustomerBobId = 2;
        public const int RestaurantItalianBistroId = 1;
        public const int RestaurantSpicyDelightId = 2;
        public const int ReservationAliceItalianBistroId = 1;
        public const int ReservationBobSpicyDelightId = 2;
        public const int CommentAliceItalianBistroId = 1;
        public const int CommentBobSpicyDelightId = 2;
    }

    public static class TestDataStrings
    {
        public const string CustomerAliceName = "Alice";
        public const string CustomerAliceEmail = "alice@example.com";
        public const string CustomerBobName = "Bob";
        public const string CustomerBobEmail = "bob@example.com";
        public const string RestaurantItalianBistroName = "Italian Bistro";
        public const string RestaurantItalianBistroLocation = "City Center";
        public const string RestaurantSpicyDelightName = "Spicy Delight";
        public const string RestaurantSpicyDelightLocation = "Downtown";
        public const string CommentAliceText = "Great food!";
        public const string CommentBobText = "Average service.";
    }

    public class Seed
    {
        public static void SeedData(ModelBuilder builder)
        {
            // Seeding customers
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = TestDataIds.CustomerAliceId,
                    Name = TestDataStrings.CustomerAliceName,
                    Email = TestDataStrings.CustomerAliceEmail,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Customer
                {
                    Id = TestDataIds.CustomerBobId,
                    Name = TestDataStrings.CustomerBobName,
                    Email = TestDataStrings.CustomerBobEmail,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                }
            );

            // Seeding restaurants
            builder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = TestDataIds.RestaurantItalianBistroId,
                    Name = TestDataStrings.RestaurantItalianBistroName,
                    Location = TestDataStrings.RestaurantItalianBistroLocation,
                    AvailableTableCount = 10,
                    Cuisine = Cuisine.Italian,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Restaurant
                {
                    Id = TestDataIds.RestaurantSpicyDelightId,
                    Name = TestDataStrings.RestaurantSpicyDelightName,
                    Location = TestDataStrings.RestaurantSpicyDelightLocation,
                    AvailableTableCount = 8,
                    Cuisine = Cuisine.Mexican,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                }
            );

            // Seeding reservations
            builder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = TestDataIds.ReservationAliceItalianBistroId,
                    ReservationDate = new DateTime(2023, 1, 15),
                    PersonCount = 2,
                    CustomerId = TestDataIds.CustomerAliceId,
                    RestaurantId = TestDataIds.RestaurantItalianBistroId,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Reservation
                {
                    Id = TestDataIds.ReservationBobSpicyDelightId,
                    ReservationDate = new DateTime(2023, 1, 20),
                    PersonCount = 3,
                    CustomerId = TestDataIds.CustomerBobId,
                    RestaurantId = TestDataIds.RestaurantSpicyDelightId,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                }
            );

            // Seeding comments
            builder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = TestDataIds.CommentAliceItalianBistroId,
                    CommentText = TestDataStrings.CommentAliceText,
                    Rating = 4.5,
                    CustomerId = TestDataIds.CustomerAliceId,
                    RestaurantId = TestDataIds.RestaurantItalianBistroId,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Comment
                {
                    Id = TestDataIds.CommentBobSpicyDelightId,
                    CommentText = TestDataStrings.CommentBobText,
                    Rating = 3.0,
                    CustomerId = TestDataIds.CustomerBobId,
                    RestaurantId = TestDataIds.RestaurantSpicyDelightId,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                }
            );
        }
    }
}
