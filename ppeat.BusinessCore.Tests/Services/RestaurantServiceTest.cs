using NSubstitute;
using ppeat.BusinessCore.Contracts;
using ppeat.BusinessCore.Services;
using ppeat.DataAccess.Tests;

namespace ppeat.BusinessCore.Tests.Services;

/// <summary>
/// Hier sollten alle Methoden des RestaurantServices getestet werden
/// </summary>
[TestClass]
public class RestaurantServiceTest
{
    [TestMethod]
    public async Task UploadRestaurantImageAsync_ShouldUploadFile()
    {
        // Assert
        var restaurantId = Guid.NewGuid();
        using var dbContext = new TestDatabase().CreateDbContext();
        var mock = Substitute.For<IFileService>();
        var service = new RestaurantService(dbContext, mock);

        // Act
        var result = service.UploadRestaurantImageAsync(restaurantId, new MemoryStream(), "file.jpg");

        // Assert
        Assert.IsFalse(string.IsNullOrEmpty(result.Result), "Datei konnte nicht hochgeladen werden");
    }

    // TODO: Weitere Tests
}
