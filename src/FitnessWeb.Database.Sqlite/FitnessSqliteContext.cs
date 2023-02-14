using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database.Sqlite;

public class FitnessSqliteContext : FitnessDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string dbName = "fitness_planner.db";
        string dbPath = Path.Combine(appdata, dbName);
        optionsBuilder
            .UseSqlite($"Data Source={dbPath}");
    }
}
