using BuisnessLogicLayer.IServices;
using BuisnessLogicLayer.MiddleWares;
using BuisnessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OrderingBookingModule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/OrderLineGet_Logs.txt",rollingInterval: RollingInterval.Minute)
                .MinimumLevel.Warning()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:OrderingBookingConnectionString"));
           
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IWishListService, WishListService>();    
            builder.Services.AddScoped<IOrderLineItemsService, OrderLineItemsService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}