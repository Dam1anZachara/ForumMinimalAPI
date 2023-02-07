using System.Security.Principal;

namespace ForumMinimalAPI.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
