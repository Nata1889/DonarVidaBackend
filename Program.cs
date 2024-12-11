using BackendFinal.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();
string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<BackendContext>(options => options.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion),
    options => options.EnableRetryOnFailure(
                                        maxRetryCount: 5,
                                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                                       errorNumbersToAdd: null)
));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar una pol?tica de CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder => builder
//            .AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod());
//});

//var app = builder.Build();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://donarvidaweb.azurewebsites.net/", "http://localhost:5198") //puerto de tu frontend
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//.UseCors("AllowAll");
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
