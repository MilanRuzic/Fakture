using Application.BusinessLogic.Invoices.Models;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDetailsViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceDetailsViewModel> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _context.Set<Invoice>()
                .ProjectTo<InvoiceDetailsViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(i => i.InvoiceId == request.InoviceId);
            invoice ??= new InvoiceDetailsViewModel();
            return invoice;
        }
    }
}
