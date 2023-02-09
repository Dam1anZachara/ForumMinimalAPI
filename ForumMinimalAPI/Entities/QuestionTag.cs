namespace ForumMinimalAPI.Entities
{
    public class QuestionTag
    {
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
