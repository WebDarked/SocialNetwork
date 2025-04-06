using SocialNetwork.domain;

namespace SocialNetwork.services.token;

public interface ITokenProvider
{
    string GetToken(User user);
}