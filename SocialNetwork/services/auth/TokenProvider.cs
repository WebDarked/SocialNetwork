using SocialNetwork.domain;

namespace SocialNetwork.services.auth
{
    internal sealed class TokenProvider(IConfiguration configuration)
    {
        public string Create(User user)
        {
            string secretKey = configuration["Jwt:Secret"] ?? throw new ArgumentNullException("Jwt secret key is null");

            var secureKey = new SymmetricSecurityKey()
        }
    }
}
