using Microsoft.EntityFrameworkCore;
using VoingPracticalTestAPI.Automapper;
using VoingPracticalTestData;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InitializeAutoMapper();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
        options => options.WithOrigins("https://voingtestweb.azurewebsites.net")
     .AllowAnyMethod()
     .AllowAnyHeader()
    );

app.UseAuthorization();

app.MapControllers();

app.Run();
