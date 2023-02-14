using Core.Entities.Exercises;
using Core.Entities.Users;

namespace Core.Services;

public interface IUserService<TId>
    where TId : struct, IComparable<TId>, IEquatable<TId>
{
    Task<User> GetUserAsync(TId userId, CancellationToken cancellationToken = default);
    Task<User> CreateUserAsync(string firstName, string lastName, DateTime dateOfBirth, CancellationToken cancellationToken = default);
    Task<User> RemoveUserAsync(TId userId, CancellationToken cancellationToken = default);
    Task AddUserPlanAsync(TId userId, WorkoutPlan plan, CancellationToken cancellationToken = default);
    Task RemoveUserPlanAsync(TId userId, WorkoutPlan plan, CancellationToken cancellationToken = default);
}