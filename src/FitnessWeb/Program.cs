using Core.Services;
using FitnessWeb.Database.Sqlite.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Add services without knowledge of implementation!
// builder.Services
//     .AddTransient<IEquipmentService<Guid>, EquipmentService>(
//         s => new EquipmentService(
//             new EquipmentSqliteRepository()))
//     .AddTransient<IExerciseService<Guid>, ExerciseService>(
//         s => new ExerciseService(new ExerciseSqliteRepository()))
//     .AddTransient<IFitnessService<Guid>, FitnessService>(
//         s => new FitnessService(
//             new WorkoutPlanSqliteRepository(),
//             new ExerciseRoutineSqliteRepository(),
//             new UserSqliteRepository()))
//     .AddTransient<IUserService<Guid>, UserService>(
//         s => new UserService(new UserSqliteRepository()))
//     .AddTransient<IMuscleService<Guid>, MusclesService>(
//         s => new MusclesService(new MuscleSqliteRepository()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
