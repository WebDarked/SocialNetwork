using SocialNetwork.DataContracts.auth;
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
            throw new UserNotFoundException(request.Email);
        
        if (!PasswordHashHelper.VerifyPassword(request.Password, user.PasswordHash))
            throw new WrongLoginDataException("Wrong password or email");

        return tokenProvider.GetToken(user);
    }
}