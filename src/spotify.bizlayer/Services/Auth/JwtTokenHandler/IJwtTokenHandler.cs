using spotify.datalayer.EfClasses;

namespace spotify.bizlayer.Services;
public interface IJwtTokenHandler
{
    string GenerateAccessToken(User user, string token);
    string GenerateRefreshToken();
}
