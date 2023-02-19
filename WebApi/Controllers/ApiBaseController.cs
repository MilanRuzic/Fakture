using Application.Common.Infrastructure.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : ControllerBase
    {
        private ISender _mediator = null!;
        public readonly IOptions<AppSettings> _appSettings;


        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();


        public ApiBaseController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected string CreateToken(int userId)
        {
            string retValue = string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            retValue = tokenHandler.WriteToken(token);

            return retValue;
        }

    }
}
