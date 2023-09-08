namespace Final_Project_Web_Application.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public List<Post> ThreadPosts { get; set; }
    }
}
