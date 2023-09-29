using System.ComponentModel.DataAnnotations;

namespace Final_Project_Web_Application.Models
{
    public class NewsItem
    {
        [Key] public int ID { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string BackgroundURL { get; set; }
    }
}
