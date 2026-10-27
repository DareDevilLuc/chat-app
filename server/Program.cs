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



var app = builder.Build();

app.UseCors("client");

app.UseHttpsRedirection();

app.Run();

