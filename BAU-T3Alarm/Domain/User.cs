using System;

namespace Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string AuthenticationToken()
        {
            return Base64Encode(string.Format("{0}:{1}", Username, Password));
        }

        public string Base64Encode(string plainText)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));
        }
    }
}