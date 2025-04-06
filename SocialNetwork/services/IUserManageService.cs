using SocialNetwork.DataContracts.auth;

namespace SocialNetwork.services;

public interface IUserManageService
{
    Task<string> Login(LoginRequest request);
}