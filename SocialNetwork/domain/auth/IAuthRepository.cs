using SocialNetwork.domain;

namespace SocialNetwork.domain.auth
{
    public interface IAuthRepository
    {
        Task<bool> IsUserWithEmailExist(string email);

        Task<Guid> RegisterUser(User user);
    }
}
