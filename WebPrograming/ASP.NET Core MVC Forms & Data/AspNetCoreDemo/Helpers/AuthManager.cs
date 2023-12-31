﻿using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

namespace AspNetCoreDemo.Helpers
{
	public class AuthManager
	{
		private readonly IUsersService usersService;

		public AuthManager() { }
		public AuthManager(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		public virtual User TryGetUser(string username)
		{
			try
			{
				return usersService.GetByUsername(username);
			}
			catch (EntityNotFoundException)
			{
				throw new UnauthorizedOperationException("Invalid username!");
			}
		}
	}
}
