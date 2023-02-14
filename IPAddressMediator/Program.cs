using IPAddressMediator.Data;
using IPAddressMediator.HttpResponseIPAddress;
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
            builder.Services.AddScoped<HttpClientResponse>();
            builder.Services.AddScoped<HttpResponseConverter>();

            // Add MediatR
            builder.Services.AddMediatR(typeof(Program));

            builder.Services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("IPDb"));
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