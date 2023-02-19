using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.InvoiceItems.Command.DeleteInvoiceItemCommand
{
    public class InvoiceItemDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
