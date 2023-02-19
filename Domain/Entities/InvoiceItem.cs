using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class InvoiceItem
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

    public bool Active { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
