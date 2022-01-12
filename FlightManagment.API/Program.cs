using FlightManagment.Configurations.MapperConfig;
using FlightManagment.DAL;
using FlightManagment.Repository.Contracts;
using FlightManagment.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAirportRepository, AirporteRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
//builder.Services.AddScoped<IFlightsRepository, FlightsRepository>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Cors policy", b =>
    {
        b.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Flight Managment API",
        Version = "v1",
        Description = "Flight Managment API demo project"
    });
    var xFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xPath = Path.Combine(AppContext.BaseDirectory, xFile);
    x.IncludeXmlComments(xPath);
});
builder.Host.UseSerilog((context, loggingConfig) =>
{
    loggingConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Managment API v1");
    });
}

app.UseCors("Cors policy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
