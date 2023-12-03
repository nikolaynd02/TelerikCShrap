using BeerOverflow.Helpers;
using BeerOverflow.Repositories;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace BeerOverflow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddSingleton<IBeersRepository, BeersRepository>();
            builder.Services.AddSingleton<IStylesRepository, StylesRepository>();
            builder.Services.AddSingleton<IUsersRepository, UsersRepository>();

            builder.Services.AddScoped<IBeersService, BeersService>();
            builder.Services.AddScoped<IStylesService, StylesService>();
            builder.Services.AddScoped<IUsersService, UsersService>();

            builder.Services.AddScoped<ModelMapper>();
            builder.Services.AddScoped<AuthManager>();

            builder.Services.AddControllers();


            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
