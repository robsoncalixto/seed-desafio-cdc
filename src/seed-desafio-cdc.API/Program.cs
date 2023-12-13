using Microsoft.EntityFrameworkCore;
using seed_desafio_cdc.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DbContextPostgres>( opt =>  opt.UseNpgsql(builder.Configuration.GetConnectionString("seed_desafio_cdc")));
builder.Services.AddScoped<IAuthorRepository,AuthorRepository>(); 
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

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

public partial class Program(){}