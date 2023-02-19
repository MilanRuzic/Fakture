using Application.BusinessLogic.Users.Login.Models;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.BusinessLogic.Users.Login.Queries
{
    public class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery, LoggedInUserViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByEmailAndPasswordQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoggedInUserViewModel> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var passHash = GeneratePassHash(request.Password);

            var checkEmailUser = await _context.Set<User>()
                .ProjectTo<LoggedInUserViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Email == request.Email &&  u.Password == passHash);


            
                if (checkEmailUser == null || checkEmailUser.Id <= 0)
                {
                    throw new ValidationException("incorect_email_or_password");
                }

            checkEmailUser.Password = null;
            return checkEmailUser;
        }
        private string GeneratePassHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
