using ACD.Infrastructure.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using ACD.Api.Services.WhatsappCloud.SendMessage;


///Section to configure the log file    
#region ConfigureLogFile

var logFolder = "Logs";
if (!Directory.Exists(logFolder))
{
    Directory.CreateDirectory(logFolder);
}

var currentDateTime = DateTime.Now.Date;
var logFileName = $"Log_{currentDateTime:yyyy_MM_dd}.txt";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error() // <-- Sets the minimum log level to Error
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File($"{logFolder}/{logFileName}", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Starting up");

#endregion

var builder = WebApplication.CreateBuilder(args);

//Enable using Serilog
builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddControllers();



//Inject services
builder.Services.AddSingleton<IWhatsappCloudSendMessage, WhatsappCloudSendMessage>();


builder.Services.AddEndpointsApiExplorer();


// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo { Title = "API Test con WhatsApp V1.0", Version = "v1" });

    //Enable Annotations
    opts.EnableAnnotations();

    // Configure XML documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opts.IncludeXmlComments(xmlPath);

});


///Extension method to register all the dependencies
builder.Services.AddAutoMapper(typeof(Program));

// Register the infrastructure dependencies
builder.Services.RegisterInfrastureDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
