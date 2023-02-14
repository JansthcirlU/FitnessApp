using Core.Entities.Exercises;
using Core.Entities.Users;
using Core.Repositories;

namespace Core.Services;

public class UserService : IUserService<Guid>
{
    private readonly IRepository<User, Guid> _userRepository;

    public UserService(IRepository<User, Guid> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.FindAsync(userId);
        if (user is null) throw new ArgumentException($"Could not find user with id {userId}.", nameof(userId));
        return user;
    }

    public async Task<User> CreateUserAsync(string firstName, string lastName, DateTime dateOfBirth, CancellationToken cancellationToken = default)
    {
        User user = new(firstName, lastName, dateOfBirth);
        await _userRepository.AddAsync(user);
        return user;
    }

    public async Task<User> RemoveUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.FindAsync(userId, cancellationToken);
        if (user is null) throw new ArgumentException($"There exists no user with id {userId}.", nameof(userId));
        
        await _userRepository.RemoveAsync(user);
        return user;
    }

    public async Task AddUserPlanAsync(Guid userId, WorkoutPlan plan, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.FindAsync(userId, cancellationToken);
        if (user is not User u) throw new ArgumentException($"There exists no user with id {userId}.", nameof(userId));
        u.AddPlan(plan);
        await _userRepository.SaveChangesAsync();
    }

    public async Task RemoveUserPlanAsync(Guid userId, WorkoutPlan plan, CancellationToken cancellationToken = default)
    {
        User? user = await _userRepository.FindAsync(userId, cancellationToken);
        if (user is not User u) throw new ArgumentException($"There exists no user with id {userId}.", nameof(userId));

        u.RemovePlan(plan);
        await _userRepository.SaveChangesAsync();
    }
}