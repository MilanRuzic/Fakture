using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FluentValidation;

namespace Application.BusinessLogic.Users.Register.Commands
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            List<User> users = _context.Set<User>().ToList();


            var checkEmailUser = users.Where(u => u.Email == request.Email).FirstOrDefault();
            if (checkEmailUser == null)
            {
                var newUser = new User
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = GeneratePassHash(request.Password),
                    PhoneNumber = request.PhoneNumber
                };
                _context.Set<User>().Add(newUser);
                await _context.SaveChangesAsync(cancellationToken);

                return newUser.Id;
            }
            throw new ValidationException("email_exists");
        
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
