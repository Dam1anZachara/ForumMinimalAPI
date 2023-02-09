namespace ForumMinimalAPI.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
        //rel many Questions to many Tags
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
