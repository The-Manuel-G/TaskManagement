using TaskManagement.Services;
using TaskManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registro de servicios y repositorios
builder.Services.AddScoped<ITaskService, TaskService>(); // Registro correcto
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
