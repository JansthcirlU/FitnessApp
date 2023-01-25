using Core.Entities.Exercises;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database.Sqlite.Repositories;

public class ExerciseRoutineSqliteRepository : 
    SqliteRepository<ExerciseRoutine>
{
    public override async Task<IQueryable<ExerciseRoutine>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<ExerciseRoutine> routines = await base.GetAllAsync(cancellationToken);
        return routines
            .Include(r => r.Exercise);
    }
}