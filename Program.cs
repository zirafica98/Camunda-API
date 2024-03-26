using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");
var myOrigins = "myOrigins";

var configuration = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();


//configure CORS polisy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins(configuration.GetSection("AppSettings:CorsPolicyExceptions").Get<string[]>())
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("camunda", httpClient =>
{
    httpClient.BaseAddress = new Uri(configuration.GetSection("BaseAddresses:Camunda").Get<string>());
});

builder.Services.AddHttpClient("codebookRetail", httpClient =>
{
    httpClient.BaseAddress = new Uri(configuration.GetSection("BaseAddresses:CodebookRetail").Get<string>());
});

builder.Services.AddHttpClient("codebookCorporate", httpClient =>
{
    httpClient.BaseAddress = new Uri(configuration.GetSection("BaseAddresses:CodebookCorporate").Get<string>());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();