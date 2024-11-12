using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infra.Model.Dtos;
using Infrastructure.Model.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EGM.AracKiralama.BL.Concretes
{

    public class AuthService:IAuthService
    {
        IConfiguration _configuration;
        private readonly IAracKiralamaRepository _repository;
        public AuthService(IConfiguration configuration, IAracKiralamaRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<ResultDto<JwtDto>> LoginAsync(LoginDto item)
        {
            JwtDto jwtDto = new JwtDto();



            //LADP yapılabilir
            /*
              string AdPath = _configuration.GetSection("AppSettings")["ADPath"];
        string AdNode = _configuration.GetSection("AppSettings")["ADNode"];


        using (var principalContext = new PrincipalContext(ContextType.Domain, AdPath, AdNode))
        {
            var isLDAPKullancisi = principalContext.ValidateCredentials(userName, password);

             if(!isLDAPKullancisi)
                return new ResultDto(StatusCodeEnum.Unauthorized, "Kullanıcı adı veya parola yanlış.");
        }
             */
            //Veri tabanı login kontrolude olabilir            
            if (!(item.EPosta == "mcavdar@gmail.com" && item.Password == "Aa123"))
            {
                return ResultDto<JwtDto>.Error("EPosta veya paralo yanlış");
            }

            var userdto = await _repository.GetProjectAsync<User, UserDto>(d => d.EPosta == item.EPosta);
            userdto.Roles = new List<string>();
            userdto.Roles.Add("admin");

            var token =  CreateToken(userdto);

            jwtDto.Token = token;

            return ResultDto<JwtDto>.Success(jwtDto);
        }

        private string CreateToken(UserDto user)
        {
            //var jwtSettings = _configuration.GetSection("JwtSettings").;
            var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var crendentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(jwtSettings.ExpiryMinutes);


            var claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            claims.Add(new Claim("name", user.Name));
            claims.Add(new Claim("surname", user.Surname));
            foreach (var item in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));

            }



            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                signingCredentials: crendentials,
                expires: expires,
                claims: claims

                );


            return new JwtSecurityTokenHandler().WriteToken(token);

        }



    }
}
