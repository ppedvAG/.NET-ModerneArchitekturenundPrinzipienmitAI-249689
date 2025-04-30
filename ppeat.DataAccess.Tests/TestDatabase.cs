using Microsoft.EntityFrameworkCore;
using ppeat.DataAccess.Data;

namespace ppeat.DataAccess.Tests;

public class TestDatabase
{
    private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Initial Catalog=PpeatUnitTests;Trusted_Connection=True;MultipleActiveResultSets=true";
    
    private static readonly object _object = new object();
    private static bool _isCreated = false;

    public ApplicationDbContext CreateDatabase()
    {
        lock(_object)
        {
            var context = CreateDbContext();

            if (!_isCreated)
            {

                // Vor jedem Test Database löschen
                context.Database.EnsureDeleted();

                // Database erstellen
                context.Database.EnsureCreated();

                // Database mit Daten füllen
                context.Database.Migrate();

                _isCreated = true;
            }

            return context;
        }
    }

    public ApplicationDbContext CreateDbContext()
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(ConnectionString);
        var context = new ApplicationDbContext(builder.Options);
        return context;
    }
}