using Instagram_Private_API.src;
using System;

namespace Instagram_Private_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Client.debuger = false;

            string username = "";
            string password = "";
            Client.Login(username, password);

            try
            {
                
            }
            catch { }

            Client.Logout();
            Console.ReadKey();
        }
    }
}
