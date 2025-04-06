using SocialNetwork.Datacontracts.common;

namespace SocialNetwork.DataContracts.auth;

public record LoginRequest : IRequest
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}