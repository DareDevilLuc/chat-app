using server.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors(options => {
    options.AddPolicy("client", policy => {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
        });
    });

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=chatapp.db"));

var app = builder.Build();

app.UseCors("client");

app.UseHttpsRedirection();

app.Run();

