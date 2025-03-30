using SocialNetwork.Datacontracts.common;

namespace SocialNetwork.DataContracts.auth
{
    public record RegisterRequest : IRequest
    {
        public RegisterRequest(string firstName, string lastName, DateTime birthday, string city, string email, string aboutMe, Sex sex)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            City = city;
            Email = email;
            AboutMe = aboutMe;
            Sex = sex;
        }

        public string AboutMe { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime Birthday { get; }

        public string City { get; }

        public string Email { get; }

        public Sex Sex { get; set; }
    }
}
