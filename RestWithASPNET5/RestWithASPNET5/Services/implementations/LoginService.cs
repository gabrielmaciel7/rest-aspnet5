using RestWithASPNET5.Configurations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Repositories;
using RestWithASPNET5.Services.models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestWithASPNET5.Services.implementations
{
    public class LoginService : ILoginService
    {
        private readonly string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private readonly TokenConfiguration _configuration;

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginService(TokenConfiguration configuration, IUserRepository userRepository, ITokenService tokenService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _userRepository.ValidateCredentials(userCredentials);

            if (user == null) return null;

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _userRepository.RefreshUserInfo(user);

            var createdDate = DateTime.Now;
            var expirationDate = createdDate.AddMinutes(_configuration.Minutes);
          
            return new TokenVO
                (true, createdDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var userName = principal.Identity.Name;
            var user = _userRepository.ValidateCredentials(userName);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now) 
                return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _userRepository.RefreshUserInfo(user);

            var createdDate = DateTime.Now;
            var expirationDate = createdDate.AddMinutes(_configuration.Minutes);

            return new TokenVO
                (true, createdDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), accessToken, refreshToken);
        }
    }
}
