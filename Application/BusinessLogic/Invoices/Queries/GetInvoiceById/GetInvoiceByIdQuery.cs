using Application.BusinessLogic.Invoices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceDetailsViewModel>
    {
        public int InoviceId { get; set; }
    }
}
