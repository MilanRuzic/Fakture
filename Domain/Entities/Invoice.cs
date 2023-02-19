using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public string Partner { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; } = new List<InvoiceItem>();
}
