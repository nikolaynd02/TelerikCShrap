using BeerOverflow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Initializer.Generators
{
    internal class UserGenerator
    {
        internal static UserDb[] CreteUsers()
        {
            string[] usernames = new string[]
            {
                "tester",
                "admin"
            };
            string[] firstnames = new string[]
            {
                "Dragan",
                "Nikolay"
            };

            string[] lastnames = new string[]
            {
                "Draganov",
                "Dobrev"
            };

            string[] passwords = new string[]
            {
                "12345",
                "admin"
            };

            string[] emails = new string[]
            {
                "tester@mail.com",
                "admin@mail.com"
            };

            bool[] areAdmins = new bool[]
            {
                false,
                true
            };


            int usersCount = usernames.Length;

            UserDb[] userDbs = new UserDb[usersCount];

            for (int i = 0; i < usersCount; i++)
            {
                UserDb currUser = new UserDb()
                {
                    Id = i + 1,
                    Username = usernames[i],
                    FirstName = firstnames[i],
                    LastName = lastnames[i],
                    Password = passwords[i],
                    Email = emails[i],
                    IsAdmin = areAdmins[i],
                };

                userDbs[i] = currUser;
            }

            return userDbs;

        }
    }
}
