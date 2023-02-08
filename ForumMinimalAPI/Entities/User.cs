namespace ForumMinimalAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //rel one User to many Questions
        public IQueryable<Question> Questions { get; set; }

        //rel one User to many Comments
        public IQueryable<Comment> Comments { get; set; }

        //rel one User to one Address
        public Address Address { get; set; }
        //public int AddressId { get; set; }

        //rel one User to many ratings
        public IQueryable<Rating> Ratings { get; set; }
    }
}
