using Application.BusinessLogic.InvoiceItems.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.InvoiceItems.Queries.GetInvoiceItemById
{
    public class GetInvoiceItemByIdQuery : IRequest<InvoiceItemViewModel>
    {
        public int Id { get; set; }
    }
}
