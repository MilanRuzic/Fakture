using Application.BusinessLogic.InvoiceItems.Command.DeleteInvoiceItemCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Commands.DeleteInvoiceCommand
{
    public class DeleteInvoiceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
