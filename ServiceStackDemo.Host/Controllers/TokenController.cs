using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.OrmLite;
using ServiceStackDemo.Host.Model;
using ServiceStackDemo.Core;
using ServiceStackDemo.Db;
using ServiceStackDemo.Domain.Repository;

namespace ServiceStackDemo.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User,long> _userRepository;

        public TokenController(
            IConfiguration configuration,
            IRepository<User, long> userRepository
            )
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult GetToken(string userName, string pwd)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userName))
                return BadRequest(new { message = "username or password is error." });
            
            if (!_userRepository.Exists(i => i.UserName == userName && i.Password == EncryptHelper.Md5(pwd)))
            {
                return BadRequest(new { message = "username or password is error." });
            }

            var claims = new[]
                {
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                   new Claim(ClaimTypes.NameIdentifier, userName)
                };

            var token = CreateAccessToken(claims);
            return Ok(new { token });
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var config = ConfigurationBinder.Get<Authentication>(_configuration.GetSection(typeof(Authentication).Name));
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config.JwtBearer.Issuer,
                audience: config.JwtBearer.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? TimeSpan.FromSeconds(config.JwtBearer.Expiration)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.JwtBearer.SecurityKey)), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        [HttpPost]
        public IActionResult Register([FromBody]ReqRegisterBody req)
        {
            var model = new User() { UserName = req.UserName ,Password= EncryptHelper .Md5(req.Pwd)};
            _userRepository.Insert(model);
            return Ok(new { model });
        }
    }

}