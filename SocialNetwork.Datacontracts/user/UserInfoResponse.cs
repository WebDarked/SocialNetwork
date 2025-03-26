using SocialNetwork.Datacontracts.@base;

namespace SocialNetwork.Datacontracts.user
{
    public sealed record UserInfoResponse(Guid Id, string FirstName, string LastName, DateTime Birthday, string City, string AboutMe) : IResponse;
}
