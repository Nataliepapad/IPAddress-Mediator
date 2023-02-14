using IPAddressMediator.Commands;
using IPAddressMediator.Data;
using IPAddressMediator.IP2CIntegration;
using IPAddressMediator.Persistence;
using IPAddressMediator.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IPAddressMediator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton(x => new HttpClient());
            builder.Services.AddScoped<IAddCountry, AddCountry>();
            builder.Services.AddScoped<IAddIPAddress, AddIPAddress>();
            builder.Services.AddScoped<IAddCountryPersistence, AddCountryPersistence>();
            builder.Services.AddScoped<IAddIPAddressPersistence, AddIPAddressPersistence>();
            builder.Services.AddScoped<IIP2CClient, IP2CClient>();
            builder.Services.AddScoped<IResponseParser, ResponseParser>();
            builder.Services.AddScoped<IIPAddressService, IPAddressService>();
            builder.Services.AddScoped<IStatisticsService, StatisticsService>();

            // Add MediatR
            builder.Services.AddMediatR(typeof(Program).Assembly);

            builder.Services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("IPAddressSQLConn"));
            });

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

            app.Run();
        }
    }
}