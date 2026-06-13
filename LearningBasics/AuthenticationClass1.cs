using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class UserAuthentication
    {

        public bool ValidateJwtToken(string token)
        {
            var tokenHandlerz = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            var tokenParemeter = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = false,
                ValidIssuer = "myIssuer",
                ValidAudience = "myAudience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkey1234567890mysecretkey1234567890")),
                //  ClockSkew = TimeSpan.Zero
            };

            var claimPrinsiple = tokenHandlerz.ValidateToken(token, tokenParemeter, out var validatedToken);


            var output = claimPrinsiple.Claims.ToList().Where(x => x.Type == "JIT").Select(x => x.Value).FirstOrDefault();

            //check in cache with the value of JIT claim
            if(true)      //JIT is valid and not expired
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public UserAuthenticateionResponse GetJwtTokenFromRefreshToken(string refreshToken)
        {
            // Simulate refresh token validation logic
            var result = new UserAuthenticateionResponse();
            if (refreshToken == "valid_refresh_token")
            {
                result.IsAuthenticated = true;
                result.Message = "Refresh token is valid. New JWT token generated.";
                // Generate a new JWT token
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkey1234567890mysecretkey1234567890"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new System.Security.Claims.Claim(ClaimTypes.Name, "Sayu"),
                    new System.Security.Claims.Claim("XXX", "Admin") ,
                    new System.Security.Claims.Claim("Address", "Admin") ,
                    new System.Security.Claims.Claim(ClaimTypes.Role, "Admin") ,
                     new System.Security.Claims.Claim("JIT",Guid.NewGuid().ToString()) ,
                };
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = signingCredentials,
                    Audience = "myAudience",
                    Issuer = "myIssuer",
                    IssuedAt = DateTime.UtcNow,
                };
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                result.JWTToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                result.RefreshToken = refreshToken;
                result.RefreshTokenExp = DateTime.UtcNow.AddDays(1); //Bring From Database
                //save in Database with UUID and expiry time
                return result;
            }
            else
            {
                result.IsAuthenticated = false;
                result.Message = "Invalid refresh token.";
                return result;
            }
        }


        

        public UserAuthenticateionResponse Authenticate(string userName, string password)
        {

            var result = new UserAuthenticateionResponse();
            // Simulate authentication logic
            if (userName == "admin" && password == "password")
            {
                result.IsAuthenticated = true;
                result.Message = "Authentication successful.";
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkey1234567890mysecretkey1234567890"));

                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var uuid = Guid.NewGuid().ToString();
                var claims = new[]
                   {
                    new System.Security.Claims.Claim(ClaimTypes.Name, "Sayu"),
                    new System.Security.Claims.Claim("XXX", "Admin") ,
                    new System.Security.Claims.Claim("Address", "Admin") ,
                    new System.Security.Claims.Claim(ClaimTypes.Role, "Admin") ,
                     new System.Security.Claims.Claim("JIT",uuid) ,
                 };

                // chache the UUID

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = signingCredentials,
                    Audience = "myAudience",
                    Issuer = "myIssuer",
                    IssuedAt = DateTime.UtcNow,
                };

                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

                var resulttoken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                 result.JWTToken = resulttoken;
                result.RefreshToken = Guid.NewGuid().ToString();
                  result.RefreshTokenExp = DateTime.UtcNow.AddDays(1);
                //save in Database with UUID and expiry time

                  return result;

            }
            else
            {
                result.IsAuthenticated = false;
                result.Message = "Invalid username or password.";
                return result;
            }

        }

    }
}
