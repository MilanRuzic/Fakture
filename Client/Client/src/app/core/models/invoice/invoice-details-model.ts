export class InvoiceDetailsModel
 {
   invoiceId: number;
   invoiceNumber: string;
   partner: string;
   date: Date;
   amountWithoutVat: number;
   rebatePercent: number;
   rebate: number;
   amountWithoutVatrebate: number;
   amountVat: number;
   total: number;
}
