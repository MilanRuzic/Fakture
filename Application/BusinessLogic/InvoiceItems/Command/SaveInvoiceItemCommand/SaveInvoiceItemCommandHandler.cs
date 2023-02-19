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

namespace Application.BusinessLogic.InvoiceItems.Command.SaveInvoiceItemCommand
{
    public class SaveInvoiceItemCommandHandler : IRequestHandler<SaveInvoiceItemCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SaveInvoiceItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> Handle(SaveInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                var invoiceItemFromDB = await _context.Set<InvoiceItem>().FirstOrDefaultAsync(i => i.Id == request.Id);

                if (invoiceItemFromDB == null)
                    throw new NotFoundException(nameof(Domain.Entities.Invoice), request.InvoiceId);
                invoiceItemFromDB.Name = request.Name;
                invoiceItemFromDB.Quantity = request.Quantity;
                invoiceItemFromDB.Price = request.Price;
                invoiceItemFromDB.Rebate = request.Rebate;
                invoiceItemFromDB.AmountVat = request.AmountVat;
                invoiceItemFromDB.AmountWithoutVat = request.AmountWithoutVat;
                invoiceItemFromDB.AmountWithoutVatrebate = request.AmountWithoutVatrebate;
                invoiceItemFromDB.RebatePercent = request.RebatePercent;
                invoiceItemFromDB.Total = request.Total;


                await _context.SaveChangesAsync(cancellationToken);
                return request.InvoiceId;
            }
            else
            {
                var newInvoiceItem = new Domain.Entities.InvoiceItem
                {
                    InvoiceId = request.InvoiceId,
                    Name = request.Name,
                    Quantity = request.Quantity,
                    Price = request.Price,
                    Rebate = request.Rebate,
                    AmountVat = request.AmountVat,
                    AmountWithoutVat = request.AmountWithoutVat,
                    AmountWithoutVatrebate = request.AmountWithoutVatrebate,
                    RebatePercent = request.RebatePercent,
                    Total = request.Total
                };
                _context.Set<InvoiceItem>().Add(newInvoiceItem);
                await _context.SaveChangesAsync(cancellationToken);


                return newInvoiceItem.Id;
            }
        }
    }
}
