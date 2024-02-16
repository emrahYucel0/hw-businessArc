using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business;
using Business.DependencyResolvers.Autofac;
using Business.Tools.Exceptions;
using Core.Utilities.Tools;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Core.Extensions;
using Core.DependencyResolvers;
using DataAccess.DependencyResolvers;
using Business.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Host.ConfigureServices(services =>
{
    services.AddDependencyResolvers(new() { new CoreModule(), new DataAccessModule(), new BusinessServiceModule() });
});

ServiceTool.CreateServiceProvider(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

var dbContext = ServiceTool.GetService<BusinessDbContext>();
await dbContext.Database.MigrateAsync();

app.Run();

