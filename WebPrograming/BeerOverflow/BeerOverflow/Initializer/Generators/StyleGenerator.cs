using BeerOverflow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Initializer.Generators
{
    internal class StyleGenerator
    {

        internal static StyleDb[] CreteStyles()
        {
            string[] styles = new string[]
            {
                "Draft",
                "Tester"
            };

            int stylesCount = styles.Length;

            StyleDb[] styleDbs = new StyleDb[stylesCount];

            for (int i = 0; i < stylesCount; i++)
            {
                StyleDb currStyle = new StyleDb()
                {
                    Id = i + 1,
                    Name = styles[i]
                };

                styleDbs[i] = currStyle;
            }

            return styleDbs;

        }

    }
}
