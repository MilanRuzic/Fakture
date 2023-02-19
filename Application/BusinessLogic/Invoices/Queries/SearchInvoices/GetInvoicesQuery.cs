using Application.BusinessLogic.Invoices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Queries.SearchInvoices
{
    public class GetInvoicesQuery : IRequest<List<SearchInvoicesViewModel>>
    {
        public string InvoiceNumber { get; set; }
        public string Partner { get; set; }
    }
}
