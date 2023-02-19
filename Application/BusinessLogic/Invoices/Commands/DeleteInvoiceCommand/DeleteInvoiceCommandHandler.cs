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

namespace Application.BusinessLogic.Invoices.Commands.DeleteInvoiceCommand
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceDelete = await _context.Set<Invoice>().FirstOrDefaultAsync( i=> i.Id == request.Id);
            if (invoiceDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Invoice), request.Id);

            }

            var invoiceItemsDelete = await _context.Set<InvoiceItem>().Where(item => item.InvoiceId == request.Id).ToListAsync();
            _context.Set<InvoiceItem>().RemoveRange(invoiceItemsDelete);
            _context.Set<Invoice>().Remove(invoiceDelete);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
