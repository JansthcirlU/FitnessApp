using Core.Entities.Equipment.Base;
using Core.Entities.Exercises;
using Core.Services;
using FitnessWeb.Database.Sqlite.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddTransient<IEquipmentService<Guid>, EquipmentService>(
        s => new EquipmentService(
            new SqliteRepository<Equipment>()
        ))
    .AddTransient<IExerciseService<Guid>, ExerciseService>(
        s => new ExerciseService(
            new SqliteRepository<Exercise>()
        ))
    .AddTransient<IFitnessService<Guid>, FitnessService>(
        s => new FitnessService(
            new SqliteRepository<WorkoutPlan>(),
            new SqliteRepository<ExerciseRoutine>()
        ));

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
