using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sober.Application.Common.Interfaces.Authentication;
using Sober.Application.Common.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sober.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;


        public JwtTokenGenerator(
            IDateTimeProvider dateTimeProvider
            //IOptions<JwtSettings> jwtOptions
            )
        {
            //_jwtSettings = jwtOptions.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super-secret-key-is-the-best-thing-ever")),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: "Rajib",
                audience: "Public",
                expires: _dateTimeProvider.UtcNow.AddMinutes(60),
                claims: claims,
                signingCredentials: signingCredentials);


            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
