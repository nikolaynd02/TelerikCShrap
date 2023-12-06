using BeerOverflow.Data;
using BeerOverflow.Helpers;
using BeerOverflow.Initializer;
using BeerOverflow.Repositories;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace BeerOverflow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BeerOverflowDbContext>(options =>
            {
                // A connection string for establishing a connection to the locally installed SQL Server.
                // Set serverName to your local instance; databaseName is the name of the database
                string connectionString = @"Server=localhost\SQLEXPRESS;Database=BeerOverflow;Trusted_Connection=True;";
                // Configure the application to use the locally installed SQL Server.
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            });

            builder.Services.AddScoped<IBeersRepository, BeersRepository>();
            builder.Services.AddScoped<IStylesRepository, StylesRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();

            builder.Services.AddScoped<IBeersService, BeersService>();
            builder.Services.AddScoped<IStylesService, StylesService>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            builder.Services.AddScoped<ModelMapper>();
            builder.Services.AddScoped<AuthManager>();

            builder.Services.AddControllers();

            //Seeds data to database
            //Check BeerOverflowDbContext class OnModelCreation for database seeding


            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
