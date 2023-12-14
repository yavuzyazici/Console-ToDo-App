using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Password.Models
{
    public class PasswordModel
    {

        public int Length { get; set; }
        public string Charset { get; set; }

        public string Generate()
        {
            var random = new Random();
            var password = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                password.Append(Charset[random.Next(Charset.Length)]);
            }
            return password.ToString();
        }

    }
}
