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
        public IQueryable<Rating> Ratings { get; set; }
    }
}
