namespace SocialNetwork.domain.users
{
    public interface IUserRepository
    {
        Task<bool> IsUserWithEmailExist(string email);

        Task RegisterUser(User user);
    }
}
