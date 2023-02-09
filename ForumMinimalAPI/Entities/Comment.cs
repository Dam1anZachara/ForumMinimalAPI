namespace ForumMinimalAPI.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        //rel one User to many Coments
        public User User { get; set; }
        public Guid UserId { get; set; }

        //rel one Comment to many Ratings
        public List<Rating> Ratings { get; set; } = new List<Rating>();

        //rel one Question to many Comments
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
