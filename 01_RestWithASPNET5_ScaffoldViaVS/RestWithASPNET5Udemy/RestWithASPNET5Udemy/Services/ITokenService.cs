using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNET5Udemy.Services
{
    public interface ITokenService
    {
        string GenerateAccesToken(IEnumerable<Claim>claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string Token);

    }
}
