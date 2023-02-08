namespace ForumMinimalAPI.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public bool Value { get; set; }
        //rel one User to many Ratings
        public User User { get; set; }
        public Guid UserId { get; set; }
        //rel one Comment to many Ratings
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}
