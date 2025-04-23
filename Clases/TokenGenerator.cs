using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Security.Claims;

namespace Examen_3_AppServWEB_Mi_18_20.Clases
{
    public static class TokenGenerator
    {
        public static string GenerateTokenJwt(string username, string documento, string fullName)
        {
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),           // Claim existente con el nombre de usuario del administrador
                new Claim("DocAdmin", documento),       // Nueva claim: ID del administrador
                new Claim("FullName", fullName),               // Nueva claim: Nombre completo del administrador
                // new Claim(ClaimTypes.Role, "Administrador"), // Ejemplo si tuvieras roles
            };

            // Crea el ClaimsIdentity con la lista de claims
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}