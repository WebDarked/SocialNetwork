namespace SocialNetwork.domain.users
{
    public interface IUserRepository
    {
        Task<bool> IsUserWithEmailExist(string email);

        Task AddUser(User user);
        Task<User?> GetUserByEmail(string requestEmail);
    }
}
