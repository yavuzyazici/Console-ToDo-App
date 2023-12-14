using Microsoft.AspNetCore.Mvc;

namespace Password.Models
{
    public class PasswordGeneratorModel
    {
        public int PasswordLength { get; set; }
        public string SelectedCharacters { get; set; }
        public string GeneratedPassword { get; set; }
    }

}
