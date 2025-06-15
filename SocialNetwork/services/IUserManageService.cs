using SocialNetwork.DataContracts.auth;
using SocialNetwork.domain;

namespace SocialNetwork.services;

public interface IUserManageService
{
    Task<string> Login(LoginRequest request);
    Task<bool> IsUserExist(Guid id);
    Task<User> GetUser(Guid id);
    Task<Profile?> GetUserProfile(Guid id);
}