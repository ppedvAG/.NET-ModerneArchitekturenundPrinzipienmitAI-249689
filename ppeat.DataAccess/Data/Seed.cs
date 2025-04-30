using Microsoft.EntityFrameworkCore;
using ppeat.Domain.Enums;
using ppeat.Domain.Models;

namespace ppeat.DataAccess.Data
{
    public static class TestDataIds
    {
        public const string CustomerAliceId = "550e8400-e29b-41d4-a716-446655440000";
        public const string CustomerBobId = "550e8400-e29b-41d4-a716-446655440001";
        public const string RestaurantItalianBistroId = "550e8400-e29b-41d4-a716-446655440002";
        public const string RestaurantSpicyDelightId = "550e8400-e29b-41d4-a716-446655440003";
        public const string ReservationAliceItalianBistroId = "550e8400-e29b-41d4-a716-446655440004";
        public const string ReservationBobSpicyDelightId = "550e8400-e29b-41d4-a716-446655440005";
        public const string CommentAliceItalianBistroId = "550e8400-e29b-41d4-a716-446655440006";
        public const string CommentBobSpicyDelightId = "550e8400-e29b-41d4-a716-446655440007";
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
                    Id = Guid.Parse(TestDataIds.CustomerAliceId),
                    Name = TestDataStrings.CustomerAliceName,
                    Email = TestDataStrings.CustomerAliceEmail,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Customer
                {
                    Id = Guid.Parse(TestDataIds.CustomerBobId),
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
                    Id = Guid.Parse(TestDataIds.RestaurantItalianBistroId),
                    Name = TestDataStrings.RestaurantItalianBistroName,
                    Location = TestDataStrings.RestaurantItalianBistroLocation,
                    AvailableTableCount = 10,
                    Cuisine = Cuisine.Italian,
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Restaurant
                {
                    Id = Guid.Parse(TestDataIds.RestaurantSpicyDelightId),
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
                    Id = Guid.Parse(TestDataIds.ReservationAliceItalianBistroId),
                    ReservationDate = new DateTime(2023, 1, 15),
                    PersonCount = 2,
                    CustomerId = Guid.Parse(TestDataIds.CustomerAliceId),
                    RestaurantId = Guid.Parse(TestDataIds.RestaurantItalianBistroId),
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Reservation
                {
                    Id = Guid.Parse(TestDataIds.ReservationBobSpicyDelightId),
                    ReservationDate = new DateTime(2023, 1, 20),
                    PersonCount = 3,
                    CustomerId = Guid.Parse(TestDataIds.CustomerBobId),
                    RestaurantId = Guid.Parse(TestDataIds.RestaurantSpicyDelightId),
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                }
            );

            // Seeding comments
            builder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = Guid.Parse(TestDataIds.CommentAliceItalianBistroId),
                    CommentText = TestDataStrings.CommentAliceText,
                    Rating = 4.5,
                    CustomerId = Guid.Parse(TestDataIds.CustomerAliceId),
                    RestaurantId = Guid.Parse(TestDataIds.RestaurantItalianBistroId),
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                },
                new Comment
                {
                    Id = Guid.Parse(TestDataIds.CommentBobSpicyDelightId),
                    CommentText = TestDataStrings.CommentBobText,
                    Rating = 3.0,
                    CustomerId = Guid.Parse(TestDataIds.CustomerBobId),
                    RestaurantId = Guid.Parse(TestDataIds.RestaurantSpicyDelightId),
                    CreatedDate = new DateTime(2023, 1, 1),
                    ChangedDate = new DateTime(2023, 1, 1)
                }
            );
        }
    }
}
