using BeerOverflow.Exceptions;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;

namespace BeerOverflow.Helpers
{
    public class AuthManager
    {
        private readonly IUsersService usersService;
        public AuthManager(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public User TryGerUser(string credentials)
        {
            var userInfo = credentials.Split(':');
            string username = userInfo[0];
            string password = userInfo[1];


            var user = usersService.GetByUsername(username);

            if (user.Password != password)
            {
                throw new AuthorizationException($"Invalid credentials!");
            }


            return user;


        }
    }
}
