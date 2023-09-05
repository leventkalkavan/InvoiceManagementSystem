using Application.Repositories.Invoice;
using MediatR;

namespace Application.Features.Commands.Invoice.DeleteInvoice;

public class DeleteInvoiceCommandHandler: IRequestHandler<DeleteInvoiceCommandRequest,DeleteInvoiceCommandResponse>
{
    private readonly IInvoiceWriteRepository _ınvoiceWriteRepository;

    public DeleteInvoiceCommandHandler(IInvoiceWriteRepository ınvoiceWriteRepository)
    {
        _ınvoiceWriteRepository = ınvoiceWriteRepository;
    }

    public async Task<DeleteInvoiceCommandResponse> Handle(DeleteInvoiceCommandRequest request, CancellationToken cancellationToken)
    {
        await _ınvoiceWriteRepository.RemoveAsync(request.Id);
        await _ınvoiceWriteRepository.SaveAsync();
        return new DeleteInvoiceCommandResponse()
        {
            IsSuccess = true
        };
    }
}