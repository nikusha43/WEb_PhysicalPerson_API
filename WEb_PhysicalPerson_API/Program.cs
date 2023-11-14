
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WEb_PhysicalPerson_API.Data;
using WEb_PhysicalPerson_API.Services.Implemetations;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPersonConnectionService, PersonConnectionService>();
            builder.Services.AddScoped<IPhoneService, PhoneNumberService>(); 
            // builder.Services.AddScoped<IConnectedPersonService, ConnectedPersonRepository>();

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