using System.ComponentModel.DataAnnotations;

namespace Final_Project_Web_Application.Models
{
    public class User
    {
        public enum SecurityLevel
        {
            User,
            Admin,
            Owner
        }

        [Key] public int Id { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public SecurityLevel SecLevel { get; set; }

        public string EncryptString()
        {
            return "";
        }

        public string DecryptString()
        {
            return "";
        }
    }
}
