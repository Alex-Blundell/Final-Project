namespace Final_Project_Web_Application.Models
{
    public class Forum
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ThreadsCount { get; set; }
        public int ViewsCount { get; set; }
        public int LastUserID { get; set; }
        public string LastThreadTitle { get; set; }
        public string LastThreadUpdate { get; set; }
        public List<Thread> ForumThreads { get; set; }
    }
}