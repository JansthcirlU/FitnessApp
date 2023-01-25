using Core.Entities.Exercises;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database.Sqlite.Repositories;

public class ExerciseSqliteRepository : 
    SqliteRepository<Exercise>
{
    public override async Task<IQueryable<Exercise>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<Exercise> exercises = await base.GetAllAsync(cancellationToken);
        return exercises
            .Include(e => e.RequiredEquipment)
            .Include(e => e.TrainedMuscles);
    }
}