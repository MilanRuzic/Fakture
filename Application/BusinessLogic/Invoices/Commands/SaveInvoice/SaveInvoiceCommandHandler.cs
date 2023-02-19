using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Commands.SaveInvoice
{

    public class SaveInvoiceCommandHandler : IRequestHandler<SaveInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SaveInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> Handle(SaveInvoiceCommand request, CancellationToken cancellationToken)
        {
            if (request.InvoiceId > 0)
            {
                var invoiceFromDB = await _context.Set<Invoice>().FirstOrDefaultAsync(i => i.Id == request.InvoiceId);

                if (invoiceFromDB == null)
                    throw new NotFoundException(nameof(Domain.Entities.Invoice), request.InvoiceId);

                invoiceFromDB.InvoiceNumber = request.InvoiceNumber;
                invoiceFromDB.Partner = request.Partner;
                invoiceFromDB.Date = request.Date;
                await _context.SaveChangesAsync(cancellationToken);
                return request.InvoiceId;
            }
            else
            {
                var newInvoice = new Domain.Entities.Invoice {
                InvoiceNumber = request.InvoiceNumber,
                Partner = request.Partner,
                Date = request.Date,
                };

               

                _context.Set<Invoice>().Add(newInvoice);

                await _context.SaveChangesAsync(cancellationToken);

                return newInvoice.Id;

            }

       
        }

    }
}
