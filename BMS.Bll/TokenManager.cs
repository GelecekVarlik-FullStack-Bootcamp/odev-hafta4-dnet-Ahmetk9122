using BMS.Entity.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateAccessToken(DtoLoginManager user)
        {

            // claim 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.ManagerName),
                new Claim(JwtRegisteredClaimNames.Sub,user.ManagerSurname),
                new Claim(JwtRegisteredClaimNames.Jti,user.ManagerId.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims,"Token");

            //claim roller
            var claimsRoleList = new List<Claim>
            {
                new Claim("role","Admin"),
                //new Claim("role","1"),
            };

            //security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //şifrelenmiş kimlik oluşturma
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token ayarları
            var token = new JwtSecurityToken
            (
                issuer : configuration["Tokens:Issuer"],//token dağıtıcı url
                audience : configuration["Tokens:Issuer"],//erişilebilecek apiler
                expires : DateTime.Now.AddDays(1),//token süresini bir günlük ayarlandı. Ömrü 1 gün.
                notBefore: DateTime.Now,//token üretildikten ne kadar zaman sonra devreye gireceğini ayarlıyoruz.
                signingCredentials:cred,//kimlik verildi.
                claims: claimsIdentity.Claims//claimsleri verdik.

            );

            //token oluşturma sınıfı ile örnek alıp üretmek
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;

        }


    }
}
