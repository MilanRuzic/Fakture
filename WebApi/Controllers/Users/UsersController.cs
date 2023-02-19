using Application.BusinessLogic.Users.Login.Models;
using Application.BusinessLogic.Users.Login.Queries;
using Application.BusinessLogic.Users.Register.Commands;
using Application.Common.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers.Users
{
    public class UsersController : ApiBaseController
    {
        private readonly IOptions<AppSettings> _appSettings;

        public UsersController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpPost]
        public async Task<ActionResult<LoggedInUserViewModel>> Login([FromBody] GetUserByEmailAndPasswordQuery data)
        {
            var user = await Mediator.Send(data);
            user.Token = CreateToken(user.Id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<int> RegisterUser(RegisterUserCommand data)
        {
            var user = await Mediator.Send(data);
            return user;
        }
    }
}
