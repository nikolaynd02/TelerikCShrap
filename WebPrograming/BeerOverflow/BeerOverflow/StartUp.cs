using BeerOverflow.Repositories;
using BeerOverflow.Repositories.Contracts;
using BeerOverflow.Services;
using BeerOverflow.Services.Contracts;

namespace BeerOverflow
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IBeersRepository, BeersRepository>();
            builder.Services.AddScoped<IBeerService, BeerService>();

            var app = builder.Build();
            app.MapControllers();




            app.Run();
        }
    }
}
