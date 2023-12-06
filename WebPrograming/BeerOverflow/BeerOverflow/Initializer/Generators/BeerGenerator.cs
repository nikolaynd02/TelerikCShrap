using BeerOverflow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Initializer.Generators
{
    internal class BeerGenerator
    {
        internal static BeerDb[] CreteBeers()
        {
            string[] names = new string[]
            {
                "Pirinsko",
                "Premium"
            };

            double[] abvs = new double[]
            {
                5,
                10
            };

            int beersCount = names.Length;

            StyleDb[] styles = StyleGenerator.CreteStyles();

            UserDb[] users = UserGenerator.CreteUsers();

            BeerDb[] beerDbs = new BeerDb[beersCount];

            for (int i = 0; i < beersCount; i++)
            {
                BeerDb currBeer = new BeerDb()
                {
                    Id = i + 1,
                    Name = names[i],
                    Abv = abvs[i],
                    StyleId = i + 1,
                    CreatedById = i + 1
                };

                beerDbs[i] = currBeer;
            }

            return beerDbs;

        }
    }
}
