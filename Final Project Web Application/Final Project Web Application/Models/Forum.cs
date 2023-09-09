using System.ComponentModel.DataAnnotations;

namespace Final_Project_Web_Application.Models
{
    public class Forum
    {
        [Key] public int ID { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
    }
}