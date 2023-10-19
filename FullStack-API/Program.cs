using FullStack.API.Configuration;
using FullStack_API.AppStart;

var builder = WebApplication.CreateBuilder(args);
builder.LoadConfiguration();

builder
    .ConfigureApplicationContexts()
    .ConfigureServices()
    .ConfigureSerializer();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
