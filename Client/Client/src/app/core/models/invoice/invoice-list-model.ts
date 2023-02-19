export class InvoiceListModel {
  invoiceId: number | undefined;
  invoiceNumber: string | undefined;
  partner: string | undefined;
  amountWithoutVat: number | undefined;
  rebate: number | undefined;
  amountVat: number | undefined;
  total: number | undefined;
}
