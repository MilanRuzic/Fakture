using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Commands.SaveInvoice
{
    public class SaveInvoiceCommand : IRequest<int>
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public string Partner { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
