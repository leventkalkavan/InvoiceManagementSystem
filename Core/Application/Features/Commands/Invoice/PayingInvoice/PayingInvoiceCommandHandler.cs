using Application.Repositories.Invoice;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Invoice.PayingInvoice;

public class PayingInvoiceCommandHandler: IRequestHandler<PayingInvoiceCommandRequest,PayingInvoiceCommandResponse>
{
    readonly IInvoiceWriteRepository _ınvoiceWriteRepository;
    private readonly UserManager<Domain.Entities.Authentication.AppUser> _userManager;
    private readonly IInvoiceReadRepository _ınvoiceReadRepository;
    public PayingInvoiceCommandHandler(IInvoiceWriteRepository ınvoiceWriteRepository, UserManager<Domain.Entities.Authentication.AppUser> userManager, IInvoiceReadRepository ınvoiceReadRepository)
    {
        _ınvoiceWriteRepository = ınvoiceWriteRepository;
        _userManager = userManager;
        _ınvoiceReadRepository = ınvoiceReadRepository;
    }

    public async Task<PayingInvoiceCommandResponse> Handle(PayingInvoiceCommandRequest request, CancellationToken cancellationToken)
    {
     var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return new PayingInvoiceCommandResponse
            {
                IsSuccess = false,
            };
        }
        var invoice = await _ınvoiceReadRepository.GetByIdAsync(request.InvoiceId);

        if (invoice == null)
        {
            return new PayingInvoiceCommandResponse
            {
                IsSuccess = false
            };
        }
        var paymentAmount = invoice.Bill ?? 0;

        if (user.CreditCardBalance >= paymentAmount && invoice.LastPaymentDate <= DateTime.Now)
        {
            user.CreditCardBalance -= paymentAmount;
            await _userManager.UpdateAsync(user);
            await _ınvoiceWriteRepository.RemoveAsync(request.InvoiceId);
            await _ınvoiceWriteRepository.SaveAsync();
            return new PayingInvoiceCommandResponse
            {
                IsSuccess = true
            };
        }
        return new PayingInvoiceCommandResponse
        {
            IsSuccess = false
        };
    }
}