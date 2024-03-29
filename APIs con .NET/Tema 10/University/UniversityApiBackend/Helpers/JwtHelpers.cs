﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, Guid id)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("Id", userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.Username),
                new Claim(ClaimTypes.Email, userAccounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            if(userAccounts.Role == User.UserRole.Administrator.ToString())
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }
            else 
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, out Guid id)
        {
            id = Guid.NewGuid();
            return GetClaims(userAccounts, id);
        }

        public static UserToken GenTokenKey(UserToken model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserToken();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                // Obtain SECRET KEY
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id;

                // Expires in 1 Day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validity of our token
                userToken.Validity = expireTime.TimeOfDay;

                // Generate out JWT
                var jwToken = new JwtSecurityToken(
                        issuer: jwtSettings.ValidIssuer,
                        audience: jwtSettings.ValidAudience,
                        claims: GetClaims(model, out Id),
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256
                            )
                    );

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.Username = model.Username;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
                userToken.Role = model.Role;
                userToken.WelcomeMessage = model.WelcomeMessage;

                return userToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Generating the JWT", ex);
            }
        }
    }
}
