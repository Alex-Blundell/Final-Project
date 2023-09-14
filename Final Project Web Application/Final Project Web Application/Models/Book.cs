using System.ComponentModel.DataAnnotations;

namespace Final_Project_Web_Application.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Author { get; set; }

        public Book()
        {

        }
    }
}
