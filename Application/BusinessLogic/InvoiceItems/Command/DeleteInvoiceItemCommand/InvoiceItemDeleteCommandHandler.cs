using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.InvoiceItems.Command.DeleteInvoiceItemCommand
{
    public class InvoiceItemDeleteCommandHandler : IRequestHandler<InvoiceItemDeleteCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceItemDeleteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InvoiceItemDeleteCommand request, CancellationToken cancellationToken)
        {
           var invoiceItemDelete = await _context.Set<InvoiceItem>().FirstOrDefaultAsync(item => item.Id== request.Id);

            if (invoiceItemDelete ==null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Invoice), request.Id);
            }

            _context.Set<InvoiceItem>().Remove(invoiceItemDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
