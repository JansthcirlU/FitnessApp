using Core.Entities.Exercises;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database.Sqlite.Repositories;

public class WorkoutPlanSqliteRepository : 
    SqliteRepository<WorkoutPlan>
{
    public override async Task<IQueryable<WorkoutPlan>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<WorkoutPlan> plans = await base.GetAllAsync(cancellationToken);

        return plans
            .Include(p => p.Steps)
                .ThenInclude(s => s.StepRoutine)
                    .ThenInclude(r => r.Exercise);
    }
}