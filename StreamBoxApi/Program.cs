using StreamBoxApi.Data;
using StreamBoxApi.Repositories;
using StreamBoxApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddControllers();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();


builder.Services.AddScoped<IActorRepository, ActorRepository>();

builder.Services.AddScoped<IMovieActorRepository, MovieActorRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();