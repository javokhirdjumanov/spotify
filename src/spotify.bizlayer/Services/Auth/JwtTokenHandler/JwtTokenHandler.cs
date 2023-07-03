using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using spotify.datalayer.EfClasses;
using spotify.datalayer.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace spotify.bizlayer.Services;
public class JwtTokenHandler : IJwtTokenHandler
{
    private readonly JwtOptions _jwt;
    public JwtTokenHandler(IOptions<JwtOptions> option) => _jwt = option.Value;
    public string GenerateAccessToken(User user, string token)
    {
        var claims = new List<Claim>()
        {
            new Claim(CustomClaimNames.Id, user.Id.ToString()),
            new Claim(CustomClaimNames.Email, user.Email),
            new Claim(CustomClaimNames.Role, user.Role.RoleName),
            new Claim(CustomClaimNames.Token, token)
        };

        var authSingingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwt.SecretKey));

        var jwtToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            expires: DateTime.Now.AddMinutes(_jwt.ExpirationInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(
                key: authSingingKey,
                algorithm: SecurityAlgorithms.HmacSha256)
            );

        return new JwtSecurityTokenHandler()
            .WriteToken(jwtToken);
    }
    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        using var randomGenerator = RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }
}
