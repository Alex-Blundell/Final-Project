namespace Final_Project_Web_Application.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public string PostDateTime { get; set; }
        public bool WasEdited { get; set; }
        public bool IsOP { get; set; }
    }
}
