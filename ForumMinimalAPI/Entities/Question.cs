using System.Security.Principal;

namespace ForumMinimalAPI.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        //one user to many questions
        public User User { get; set; }
        public Guid UserId { get; set; }

        //rel many Questions to many Tags
        public IQueryable<Tag> Tags { get; set; }
    }
}
