using Microsoft.EntityFrameworkCore;
using seed_desafio_cdc.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContextInMemory>( opt => opt.UseInMemoryDatabase("authors"));
builder.Services.AddScoped<IAuthorRepository,AuthorRepository>(); 

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
