using MediatR;

namespace Application.Features.Commands.Invoice.PayingInvoice;

public class PayingInvoiceCommandRequest: IRequest<PayingInvoiceCommandResponse>
{
    public string UserId { get; set; }
    public string InvoiceId { get; set; }
}