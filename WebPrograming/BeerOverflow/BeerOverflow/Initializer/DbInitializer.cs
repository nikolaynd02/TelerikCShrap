using BeerOverflow.Data.Models;
using BeerOverflow.Data;
using BeerOverflow.Initializer.Generators;
using System;

namespace BeerOverflow.Initializer
{
    public class DbInitializer
    {
        public static void ResetDatabase(BeerOverflowDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine($"BeerOverflow databse created successfully.");

            Seed(context);
        }

        public static void Seed(BeerOverflowDbContext context)
        {
            BeerDb[] beers = BeerGenerator.CreteBeers();

            context.Beers.AddRange(beers);

            context.SaveChanges();

            Console.WriteLine("Sample data inserted successfully.");
        }
    }
}
