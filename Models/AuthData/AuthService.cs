using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HusVaskeIdeBackend.Models.AuthData
{
    public class AuthService: IAuthService
    {
        public string _jwtSecret;
        public string _jwtLifespan;
        public IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
            _jwtSecret = _config.GetSection("JWT")["JWTSecretKey"];
            _jwtLifespan = _config.GetSection("JWT")["JWTLifespan"];
        }
        public AuthData GetAuthData(string id,string username)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(Convert.ToDouble(_jwtLifespan));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = id,
                Username = username,
            };
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}