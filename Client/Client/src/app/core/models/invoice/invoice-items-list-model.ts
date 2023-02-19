export class InvoiceItemsListModel {
  public id: number;
  public invoiceId: number;
  public name: string;
  public quantity: number;
  public price: number;
  public amountWithoutVat: number;
  public rebatePercent: number;
  public rebate: number;
  public amountWithoutVatrebate: number;
  public amountVat: number;
  public total: number;
}

