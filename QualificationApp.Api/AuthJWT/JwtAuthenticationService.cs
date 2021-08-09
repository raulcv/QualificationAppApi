using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QualificationApp.Domain.Interfaces.Shared;
using QualificationApp.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Infrastructure.Shared
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly string _key;
        private readonly IConfiguration _configuration;
        public JwtAuthenticationService(IConfiguration configuration)
        {
            //_key = key;
            _configuration = configuration;
        }
        //public string Authenticate(string username, string password)
        //{
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || username != "raulcv" || password != "7521")
        //    {
        //        return null;
        //    }

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenKey = Encoding.ASCII.GetBytes(_key);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, username)
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    return tokenHandler.WriteToken(token);
        //}

        public string Authentication(string usuario, string authPassword, string password, string salt)
        {
            if (HashHelper.CheckHash(authPassword, password, salt))
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                string bearerToken = tokenHandler.WriteToken(createdToken);
                return bearerToken;
            }
            else
                return null;

        }
    }
}
