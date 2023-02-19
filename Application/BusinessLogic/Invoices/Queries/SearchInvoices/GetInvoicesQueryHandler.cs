using Application.BusinessLogic.Invoices.Models;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Queries.SearchInvoices
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, List<SearchInvoicesViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInvoicesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SearchInvoicesViewModel>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _context.Set<Invoice>()
                .Where(i => (string.IsNullOrEmpty(request.InvoiceNumber) || request.InvoiceNumber != null && i.InvoiceNumber.ToLower().Contains(request.InvoiceNumber.ToLower())) &&
                (string.IsNullOrEmpty(request.Partner) || request.Partner != null && i.Partner.ToLower().Contains(request.Partner.ToLower())))
                .ProjectTo<SearchInvoicesViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            return invoices;
        }
    }
}
