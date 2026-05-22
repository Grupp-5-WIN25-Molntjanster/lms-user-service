using Lms.UserService.Application.Interfaces.Profile;
using Lms.UserService.Infrastructure.Services.Profile;
using Lms.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Lms.UserService.Application.Interfaces.Password;
using Lms.UserService.Infrastructure.Services.Password;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//kopplar entity framework till sql server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        );
});

//kopplar ihop interface med service
//Så när någon ber om IProfileService så används ProfileService

builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddScoped<IPasswordService, PasswordService>();

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