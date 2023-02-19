using Application.BusinessLogic.InvoiceItems.Command.DeleteInvoiceItemCommand;
using Application.BusinessLogic.InvoiceItems.Command.SaveInvoiceItemCommand;
using Application.BusinessLogic.InvoiceItems.Models;
using Application.BusinessLogic.InvoiceItems.Queries;
using Application.BusinessLogic.InvoiceItems.Queries.GetInvoiceItemById;
using Application.BusinessLogic.InvoiceItems.Queries.GetInvoiceItemsByInvoiceIdQuery;
using Application.BusinessLogic.Invoices.Commands.DeleteInvoiceCommand;
using Application.BusinessLogic.Invoices.Commands.SaveInvoice;
using Application.BusinessLogic.Invoices.Models;
using Application.BusinessLogic.Invoices.Queries.GetInvoiceById;
using Application.BusinessLogic.Invoices.Queries.SearchInvoices;
using Application.Common.Infrastructure.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.Invoice
{
    [Authorize]
    public class InvoiceController : ApiBaseController
    {
        public InvoiceController(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Invoice" })]
        public async Task<ActionResult<List<SearchInvoicesViewModel>>> SearchInvoices(GetInvoicesQuery request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetailsViewModel>> GetInvoiceById(int id)
        {
            return Ok(await Mediator.Send(new GetInvoiceByIdQuery { InoviceId = id }));
        }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Invoice" })]
        public async Task<ActionResult<List<SearchInvoicesViewModel>>> Save(SaveInvoiceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<InvoiceItemViewModel>>> GetInvoiceItemsByInvoiceId(int id)
        {
            return Ok(await Mediator.Send(new GetInvoiceItemsByInvoiceIdQuery { Id = id }));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItemViewModel>> GetInvoiceItemById(int id)
        {
            return Ok(await Mediator.Send(new GetInvoiceItemByIdQuery { Id = id }));
        }
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "Invoice" })]
        public async Task<ActionResult<InvoiceItemViewModel>> SaveInvoiceItem(SaveInvoiceItemCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Tags = new[] { "Invoice" })]
        public async Task<ActionResult<Unit>> DeleteInvoice(int id)
        {
            var result = await Mediator.Send(new DeleteInvoiceCommand { Id = id });
            return result;
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Tags = new[] { "Invoice" })]
        public async Task<ActionResult<Unit>> DeleteInvoiceItem(int id)
        {
            var result = await Mediator.Send(new InvoiceItemDeleteCommand { Id = id });
            return result; 
        }
    }
}
