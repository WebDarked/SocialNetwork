using SocialNetwork.DataContracts.auth;
using SocialNetwork.domain;
using SocialNetwork.domain.users;
using SocialNetwork.infrastructure.helpers;
using SocialNetwork.services.exceptions;
using SocialNetwork.services.token;

namespace SocialNetwork.services;

public class UserManageService(IUserRepository userRepository, ITokenProvider tokenProvider) : IUserManageService
{
    public async Task<string> Login(LoginRequest request)
    {
        var user = await userRepository.GetUserByEmail(request.Email);
        if ( user == null )
            throw new UserNotFoundException($"User with email = {request.Email} is not found");
        
        if (!PasswordHashHelper.VerifyPassword(request.Password, user.PasswordHash))
            throw new WrongLoginDataException("Wrong password or email");

        return tokenProvider.GetToken(user);
    }

    public async Task<bool> IsUserExist(Guid id)
    {
        return await userRepository.GetUserById(id) != null;
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await userRepository.GetUserById(id);
        if ( user == null )
            throw new UserNotFoundException($"User with id = {id} is not found");

        return user;
    }

    public async Task<Profile?> GetUserProfile(Guid id)
    {
        var user = await userRepository.GetUserById(id);
        if ( user == null )
            throw new UserNotFoundException($"User with id = {id} is not found");

        return await userRepository.GetProfile(id);
    }
}