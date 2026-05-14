using TubesKPL_Kelompok_2.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DatabaseHelper.InitializeDatabase();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();