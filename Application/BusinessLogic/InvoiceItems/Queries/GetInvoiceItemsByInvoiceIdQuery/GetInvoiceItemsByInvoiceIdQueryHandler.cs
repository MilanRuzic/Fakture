using Application.BusinessLogic.InvoiceItems.Models;
using Application.Common.Interfaces;
using Application.Common.Mappings;
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

namespace Application.BusinessLogic.InvoiceItems.Queries.GetInvoiceItemsByInvoiceIdQuery
{
    internal class GetInvoiceItemsByInvoiceIdQueryHandler : IRequestHandler<GetInvoiceItemsByInvoiceIdQuery, List<InvoiceItemViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetInvoiceItemsByInvoiceIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InvoiceItemViewModel>> Handle(GetInvoiceItemsByInvoiceIdQuery request, CancellationToken cancellationToken)
        {
            var invoiceItems = await _context.Set<InvoiceItem>()
                .Where(item => item.InvoiceId == request.Id)
                .ProjectTo<InvoiceItemViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return invoiceItems;
        }
    }
}
