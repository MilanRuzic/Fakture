export let BASECONFIG = {
  apiUrl: 'https://localhost:44384',
};

export let CONFIG = {
  invoices: {
    searchInvoices: BASECONFIG.apiUrl + '/api/Invoice/SearchInvoices',
    getInvoiceById: BASECONFIG.apiUrl + '/api/Invoice/GetInvoiceById/',
    getInvoiceItemsByInvoiceId: BASECONFIG.apiUrl + '/api/Invoice/GetInvoiceItemsByInvoiceId/',
    getInvoiceItemById: BASECONFIG.apiUrl + '/api/Invoice/GetInvoiceItemById/',
    deleteInvoiceItem: BASECONFIG.apiUrl + '/api/Invoice/DeleteInvoiceItem/',
    deleteInvoice: BASECONFIG.apiUrl + '/api/Invoice/DeleteInvoice/',
    saveInvoice: BASECONFIG.apiUrl + '/api/Invoice/Save',
    saveInvoiceItem: BASECONFIG.apiUrl + '/api/Invoice/SaveInvoiceItem',
  },
  user: {
    login: BASECONFIG.apiUrl + '/api/Users/Login',
    register: BASECONFIG.apiUrl + '/api/Users/RegisterUser',
  },
}
