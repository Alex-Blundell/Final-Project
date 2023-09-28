using System.ComponentModel.DataAnnotations;

namespace Final_Project_Web_Application.Models
{
    public class Book
    {
        public enum Category
        {
            ActionAdventure,
            Classic,
            Crime,
            Drama,
            Fantasy,
            Horror,
            Mystery,
            Non_Fiction,
            Romance,
            Satire,
            Sci_Fi,
            Thriller,
            Western,
            Young_Adult
        }

        public enum BorrowedStatus
        {
            Available,
            Borrowed,
            Reserved,
            Overdue
        }

        [Key] public int ID { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Author { get; set; }
        [Required] public string CoverURL { get; set; }
        [Required] public Category Genre { get; set; }
        [Required] public BorrowedStatus Status { get; set; }

        public Book()
        {

        }
    }

    public class BorrowedBook
    {
        [Key] public int ID { get; set; }
        [Required] public int BookID { get; set; }
        [Required] public int BorrowerID { get; set; }

        public BorrowedBook()
        {

        }
    }
}