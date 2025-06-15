using SocialNetwork.Datacontracts.common;
using SocialNetwork.DataContracts.common;

namespace SocialNetwork.DataContracts.auth
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        DateTime Birthday,
        string City,
        string Email,
        string AboutMe,
        Sex Sex,
        string Password)
        : IRequest
    {
        public Sex Sex { get; set; } = Sex;

        public string Password { get; set; } = Password;
    }
}
