// // var builder = WebApplication.CreateBuilder(args);

// // // Add services to the container.
// // // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// // builder.Services.AddOpenApi();

// // var app = builder.Build();

// // // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
// //     app.MapOpenApi();
// // }

// // app.UseHttpsRedirection();

// // var summaries = new[]
// // {
// //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// // };

// // app.MapGet("/weatherforecast", () =>
// // {
// //     var forecast =  Enumerable.Range(1, 5).Select(index =>
// //         new WeatherForecast
// //         (
// //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// //             Random.Shared.Next(-20, 55),
// //             summaries[Random.Shared.Next(summaries.Length)]
// //         ))
// //         .ToArray();
// //     return forecast;
// // })
// // .WithName("GetWeatherForecast");

// // app.Run();

// // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// // {
// //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// // }

// using BookAPI.Services;   // ✅ ADD THIS

// var builder = WebApplication.CreateBuilder(args);

// // Add services
// builder.Services.AddControllers();

// // ✅ Register BookService (IMPORTANT FIX)
// builder.Services.AddSingleton<BookService>();

// // Swagger
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Swagger UI
// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();


// using BookManagementSystem.Data;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// // ✅ Add PostgreSQL DB
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseNpgsql(
//         builder.Configuration.GetConnectionString("DefaultConnection")
//     )
// );

// // ✅ Controllers
// builder.Services.AddControllers();

// // ✅ Swagger
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // ✅ Swagger UI
// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();



using BookManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ PostgreSQL DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Controllers
builder.Services.AddControllers();

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
