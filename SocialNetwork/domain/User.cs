namespace SocialNetwork.domain
{
    public class User : IEntity
    {        
        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public string City { get; set; }

        public string AboutMe { get; set; }
        
        public Guid ProfileId { get; set; }
    }
}
