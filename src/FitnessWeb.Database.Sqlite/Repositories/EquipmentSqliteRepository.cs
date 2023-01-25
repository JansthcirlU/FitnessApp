using Core.Entities.Equipment.Base;
using Microsoft.EntityFrameworkCore;

namespace FitnessWeb.Database.Sqlite.Repositories;

public class EquipmentSqliteRepository : 
    SqliteRepository<Equipment>
{
    public override async Task<IQueryable<Equipment>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var equipment = await base.GetAllAsync(cancellationToken);
        return equipment
            .Include(e => e.Owners);
    }
}