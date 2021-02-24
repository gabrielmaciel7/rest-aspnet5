﻿using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNET5.Services.models
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}