using Application.BusinessLogic.Users.Login.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Users.Login.Queries
{
    public class GetUserByEmailAndPasswordQuery : IRequest<LoggedInUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
