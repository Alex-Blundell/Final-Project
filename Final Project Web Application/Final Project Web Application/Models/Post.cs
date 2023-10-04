using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Web_Application.Models
{
    public class Post
    {
        [Key] public int ID { get; set; }
        [Required] public int UserID { get; set; }
        [ForeignKey("ID")] public int ThreadID { get; set; }
        [Required] public int PostNum { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Message { get; set; }
        [Required] public string PostDateTime { get; set; }
        [Required] public bool WasEdited { get; set; }
    }
}
