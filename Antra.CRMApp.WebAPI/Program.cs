using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Infrastructure.Data;
using Antra.CRMApp.Infrastructure.Repository;
using Antra.CRMApp.Infrastructure.Service;
using Antra.CRMApp.WebAPI.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Serilog;
using Serilog.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<CrmDbContext>(builder.Configuration.GetConnectionString("OnlineCRM"));
builder.Services.AddLogging();

// Add services to the container.
//dependency injection for repository
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepositoryAsync>();
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();




//depedency injection for services
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IRegionServiceAsync, RegionServiceAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddScoped<ICategoryServiceAsync, CategoryServiceAsync>();
builder.Services.AddScoped<IShipperServiceAsync, ShipperServiceAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseExceptionHandler(option =>
//{
//    option.Run(
//        async context =>
//        {
//            var ex = context.Features.Get<IExceptionHandlerFeature>();
//            if (ex != null)
//            {
//                await context.Response.WriteAsync(ex.Error.Message);
//            }
//        });
//});




app.UseSerilogRequestLogging();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

