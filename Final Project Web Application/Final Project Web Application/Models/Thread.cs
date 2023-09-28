using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project_Web_Application.Models
{
    public class Thread
    {
        [Key] public int ID { get; set; }
        [ForeignKey("ID")] public int ForumID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string CreationDate { get; set; }
    }
}