using Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database.Sqlite.Repositories;

public class UserSqliteRepository :
    SqliteRepository<User>
{
    public override async Task<IQueryable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IQueryable<User> users = await base.GetAllAsync(cancellationToken);

        // This feels wrong
        return users
            .Include(u => u.Plans)
                .ThenInclude(p => p.Steps)
                    .ThenInclude(s => s.StepRoutine)
                        .ThenInclude(r => r.Exercise);;
    }
}