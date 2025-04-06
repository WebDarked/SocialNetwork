using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.domain;

namespace SocialNetwork.services.token;

public class TokenProvider(IOptions<JwtOptions> options) : ITokenProvider
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public string GetToken(User user)
    {
        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
            SecurityAlgorithms.HmacSha256Signature);

        Claim[] claims = [new ("email", user.Email)];
        
        var token = new JwtSecurityToken(
            issuer: "SocialNetworkApp",
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddHours(_jwtOptions.Expires));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}