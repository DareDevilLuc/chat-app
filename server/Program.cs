using server.Data;
using server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using SignalRChatMVC.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();

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

builder.Services.AddIdentityCore<User>()
  .AddRoles<IdentityRole<int>>()
  .AddEntityFrameworkStores<AppDbContext>();

  builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "ChatApp",
            ValidAudience = "ChatApp",

            IssuerSigningKey = new SymmetricSecurityKey(
                Convert.FromBase64String(
                    builder.Configuration["Jwt:Key"]!
                )
            )
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("client");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();
