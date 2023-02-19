using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.InvoiceItems.Models
{
    public class InvoiceItemViewModel : IMapFrom<InvoiceItem>
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? AmountWithoutVat { get; set; }
        public decimal? RebatePercent { get; set; }
        public decimal? Rebate { get; set; }
        public decimal? AmountWithoutVatrebate { get; set; }
        public decimal? AmountVat { get; set; }
        public decimal? Total { get; set; }

    }
}
