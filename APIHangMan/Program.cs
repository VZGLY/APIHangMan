using APIHangMan.Controllers;
using BLL.Services;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<WordService>();

builder.Services.AddScoped<WordRepository>(x => new WordRepository(builder.Configuration.GetConnectionString("HangmanDatabase")));

builder.Services.AddCors(o =>
{
    o.AddPolicy("default", o =>
    {
        o.AllowAnyHeader();
        o.AllowAnyMethod();
        o.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();