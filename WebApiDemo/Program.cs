using DataAccess.Repository;
using DataAccess.Repository.Implements;
using Business.Services;
using Business.Services.Implements;
using Business.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

//Define las caracteristicas del acceso cruzado - CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            //Policy.AllowAnyOrigin --> Se usa para dominios externos
            //Para el localHost funciona con SetIsOriginAllowed
            policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

//Add Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    { Title = "Api REST - Test", Version = "v1" });
});

//Dependency injection of DBContext Class
builder.Services.AddDbContext<APIDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnTestFlight")));

//Dependency injection of Repositories
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

//Dependency injection of Services
builder.Services.AddScoped<ITransportService, TransportService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();


builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//indica la ruta para generar la configuración de swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api REST");
    c.RoutePrefix = string.Empty;
});

app.Logger.LogInformation("Adding Routes");
app.MapGet("/", () => "Hello World!");
app.Logger.LogInformation("Starting the app");

app.Run();
