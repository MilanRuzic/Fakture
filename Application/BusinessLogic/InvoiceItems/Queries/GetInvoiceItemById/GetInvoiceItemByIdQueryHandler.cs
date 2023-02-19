using Application.BusinessLogic.InvoiceItems.Models;
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

namespace Application.BusinessLogic.InvoiceItems.Queries.GetInvoiceItemById
{
    public class GetInvoiceItemByIdQueryHandler : IRequestHandler<GetInvoiceItemByIdQuery, InvoiceItemViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInvoiceItemByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceItemViewModel> Handle(GetInvoiceItemByIdQuery request, CancellationToken cancellationToken)
        {
            var invoiceItem = await _context.Set<InvoiceItem>()
                .ProjectTo<InvoiceItemViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(item => item.Id == request.Id);
            invoiceItem ??= new InvoiceItemViewModel();
            return invoiceItem;
        }
    }
}
