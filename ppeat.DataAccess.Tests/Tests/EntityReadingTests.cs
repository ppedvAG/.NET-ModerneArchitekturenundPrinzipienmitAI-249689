using ppeat.DataAccess.Data;
using ppeat.Domain.Enums;

namespace ppeat.DataAccess.Tests.Tests;

[TestClass]
public class EntityReadingTests
{
    private readonly TestDatabase _testDatabase = new();

    [TestMethod]
    public void ReadCustomer_ExistingCustomer_ReturnsCustomerData()
    {
        // Arrange
        using var context = _testDatabase.CreateDatabase();

        // Act
        var customer = context.Customers.Find(Guid.Parse(TestDataIds.CustomerAliceId));

        // Assert
        Assert.IsNotNull(customer);
        Assert.AreEqual(TestDataStrings.CustomerAliceName, customer.Name);
        Assert.AreEqual(TestDataStrings.CustomerAliceEmail, customer.Email);
    }

    [TestMethod]
    public void ReadRestaurant_ExistingRestaurant_ReturnsRestaurantData()
    {
        // Arrange
        using var context = _testDatabase.CreateDatabase();

        // Act
        var restaurant = context.Restaurants.Find(Guid.Parse(TestDataIds.RestaurantItalianBistroId));

        // Assert
        Assert.IsNotNull(restaurant);
        Assert.AreEqual(TestDataStrings.RestaurantItalianBistroName, restaurant.Name);
        Assert.AreEqual(TestDataStrings.RestaurantItalianBistroLocation, restaurant.Location);
        Assert.AreEqual(Cuisine.Italian, restaurant.Cuisine);
    }

    [TestMethod]
    public void ReadReservation_ExistingReservation_ReturnsReservationData()
    {
        // Arrange
        using var context = _testDatabase.CreateDatabase();

        // Act
        var reservation = context.Reservations.Find(Guid.Parse(TestDataIds.ReservationAliceItalianBistroId));

        // Assert
        Assert.IsNotNull(reservation);
        Assert.AreEqual(new DateTime(2023, 1, 15), reservation.ReservationDate);
        Assert.AreEqual(2, reservation.PersonCount);
    }

    [TestMethod]
    public void ReadComment_ExistingComment_ReturnsCommentData()
    {
        // Arrange
        using var context = _testDatabase.CreateDatabase();

        // Act
        var comment = context.Comments.Find(Guid.Parse(TestDataIds.CommentAliceItalianBistroId));

        // Assert
        Assert.IsNotNull(comment);
        Assert.AreEqual(TestDataStrings.CommentAliceText, comment.CommentText);
        Assert.AreEqual(4.5, comment.Rating);
    }
}