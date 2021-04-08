using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Claims;
using JwtAuthentication.API.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace JwtAuthentication.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private static readonly MD5 _hashFunction = MD5.Create();

        private readonly IDictionary<string, User> _users = new Dictionary<string, User>
        {
            {"Siddharth", new User{ Username= "Siddharth", Id = 1, Password = EncryptPassword("password123") } },
            {"Tarun", new User{ Username= "Tarun", Id = 2, Password = EncryptPassword("password12113") } },
            {"Guest", new User{ Username= "Guest", Id = 3, Password = EncryptPassword("password") } }

        };

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Authenticate(string username, string password)
        {
            if (!IsUserExist(username))
                return false;

            return VerifyPassword(username, password);

        }

        public bool IsUserExist(string username) => _users.Any(u => u.Key == username);

        public bool VerifyPassword(string username, string password) => _users[username].Password.Equals(EncryptPassword(password), StringComparison.CurrentCultureIgnoreCase);

        public dynamic GenerateToken(string username)
        {
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, username),
               new Claim(ClaimTypes.NameIdentifier,_users[username].Id.ToString()),
               new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
               new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddHours(Convert.ToInt32( _configuration.GetSection("JwtConfig:ExpiryTime").Value))).ToUnixTimeSeconds().ToString())

            };

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secert").Value.ToString())),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = username
            };
        }

        private static string EncryptPassword(String input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes("med02ax" + input);
            byte[] hashBytes = _hashFunction.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2").ToLower());

            return sb.ToString();
        }
    }
}
