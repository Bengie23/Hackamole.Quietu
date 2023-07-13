using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Api.Models;

var builder = WebApplication.CreateBuilder(args);

JWTManagerOptions jwtManagerOptions = new JWTManagerOptions();
builder.Configuration.GetSection(nameof(JWTManagerOptions)).Bind(jwtManagerOptions);
builder.Services.AddSingleton<JWTManagerOptions>(jwtManagerOptions);
// Add services to the container.

builder.Services.AddTransient<IJWTManager, JWTManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
