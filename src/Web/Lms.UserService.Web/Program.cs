using Lms.UserService.Application.Interfaces.Profile;
using Lms.UserService.Application.Services.Profile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//kopplar ihop interface med service
//Så vad det gör är att när någon ber om IProfileService så används ProfileService
builder.Services.AddScoped<IProfileService, ProfileService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();