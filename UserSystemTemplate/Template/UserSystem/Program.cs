using System;

namespace UserSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            string[,] userTable = new string[4, 2];

            // main loop
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(" ");

                if (!ValidateArgument(commandArgs))
                {
                    Console.ResetColor();
                    continue;
                }

                string username = commandArgs[1];
                string password = commandArgs[2];

                if (!ValidateUser(username))
                {
                    Console.ResetColor();
                    continue;
                }

                if (!ValidatePassword(password))
                {
                    Console.ResetColor();
                    continue;
                }

                if (commandArgs[0].ToLower() == "register")
                {
                    // performs registration and neccessery check
                    CmdRegister(username, password, userTable);                
                }
                else if(commandArgs[0].ToLower() == "delete")
                {
                    // find account to delete
                    CmdDelete(username, password, userTable);
                }              
               
            }
        }

        static void CmdRegister(string username, string password, string[,] userTable)
        {
            bool usernameExists = CheckForUsername(username, userTable);

            if (usernameExists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exists.");
                Console.ResetColor();
                return;
            }

            // find free slot
            int freeSlotIndex = -1;
            for (int i = 0; i < userTable.GetLength(0); i++)
            {
                if (userTable[i, 0] == null)
                {
                    freeSlotIndex = i;
                }
            }

            // no free slots
            if (freeSlotIndex == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The system supports a maximum number of 4 users.");
                Console.ResetColor();
                return;
            }

            // save user
            userTable[freeSlotIndex, 0] = username;
            userTable[freeSlotIndex, 1] = password;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Registered user.");
            Console.ResetColor();
        }
        static void CmdDelete(string username, string password, string[,] userTable)
        {
            int accountIndex = -1;
            for (int i = 0; i < userTable.GetLength(0); i++)
            {
                if (userTable[i, 0] == username &&
                    userTable[i, 1] == password)
                {
                    accountIndex = i;
                }
            }

            if (accountIndex == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid account/password.");                
            }
            else
            {
                userTable[accountIndex, 0] = null;
                userTable[accountIndex, 1] = null;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Deleted account.");
            }

            Console.ResetColor();
        }


        static bool ValidateUser(string username)
        {
            if (username.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username must be at least 3 characters long");
                Console.ResetColor();
                return false;
            }

            return true;
        }

        static bool ValidatePassword(string password)
        {
            if (password.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must be at least 3 characters long.");
                Console.ResetColor();
                return false;
            }

            return true;
        }

        static bool ValidateArgument(string[] argument)
        {
            if (argument.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Too few parameters.");
                Console.ResetColor();
                return false;
            }

            return true;
        }

        static bool CheckForUsername(string username, string[,] userTable)
        {
            for (int i = 0; i < userTable.GetLength(0); i++)
            {
                if (userTable[i, 0] == username)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
