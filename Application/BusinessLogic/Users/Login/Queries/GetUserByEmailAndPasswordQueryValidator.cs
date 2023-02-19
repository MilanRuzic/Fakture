using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Users.Login.Queries
{
    public class GetUserByEmailAndPasswordQueryValidator : AbstractValidator<GetUserByEmailAndPasswordQuery>
    {
        public GetUserByEmailAndPasswordQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email obavezan");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lozinka obavezna");
        }
    }
}
