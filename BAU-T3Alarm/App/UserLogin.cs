using System;
using Domain;

namespace App
{
    public class UserLogin
    {
        private readonly User _user;

        public UserLogin(User user)
        {
            _user = user;
        }

        private void Login()
        {
            Console.Write("Username: ");
            _user.Username = Console.ReadLine();
            Console.Write("Password: ");
            _user.Password = ReturnPassword();
            Console.WriteLine();
        }

        public string GetAuthenticationToken()
        {
            Login();
            return _user.Base64Encode(string.Format("{0}:{1}", _user.Username, _user.Password));
        }

        private static string ReturnPassword()
        {
            var password = "";
            var info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    password += info.KeyChar;
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring
                            (0, password.Length - 1);
                    }
                    info = Console.ReadKey(true);
                }
            }
            for (var i = 0; i < password.Length; i++)
                Console.Write(@"*");
            return password;
        }
    }
}