using MediatR;

namespace Application.Features.Commands.Invoice.DeleteInvoice;

public class DeleteInvoiceCommandRequest: IRequest<DeleteInvoiceCommandResponse>
{
    public string Id { get; set; }
}