using Autofac;
using Autofac.Extensions.DependencyInjection;
using TestCase.Business.Abstract;
using TestCase.Business.Concrete;
using TestCase.Business.DependencyResolvers.Autofac;
using TestCase.Core.Extensions;
using TestCase.Core.Settings;
using TestCase.DataAccess.Abstract;
using TestCase.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MongoSettings
var dbs = builder.Configuration.GetSection("MongoConnection").Get<MongoSettings>();
builder.Services.AddSingleton<IMongoSettings, MongoSettings>(sp => { return dbs; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();