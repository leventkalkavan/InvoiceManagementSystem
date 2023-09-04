using Application.Repositories.House;
using Application.Repositories.Invoice;
using MediatR;

namespace Application.Features.Commands.Invoice.CreateInvoice;

public class CreateInvoiceCommandHandler: IRequestHandler<CreateInvoiceCommandRequest,CreateInvoiceCommandResponse>
{
    private readonly IInvoiceWriteRepository _invoiceWriteRepository;
    private readonly IHouseReadRepository _houseReadRepository;

    public CreateInvoiceCommandHandler(IInvoiceWriteRepository ınvoiceWriteRepository, IHouseReadRepository houseReadRepository)
    {
        _invoiceWriteRepository = ınvoiceWriteRepository;
        _houseReadRepository = houseReadRepository;
    }

    public async Task<CreateInvoiceCommandResponse> Handle(CreateInvoiceCommandRequest request, CancellationToken cancellationToken)
    { 
        var house = await _houseReadRepository.Table.FindAsync(request.HouseId);

        if (house == null)
        {
            return new CreateInvoiceCommandResponse
            {
                IsSuccess = false
            };
        }

        var newInvoice = new Domain.Entities.Invoice
        {
            House = house,
            Name = request.Name,
            Bill = request.Bill,
            IsPaid = request.IsPaid == false,
            CreatedDate = request.CreatedDate,
            LastPaymentDate = request.LastPaymentDate,
        };
        await _invoiceWriteRepository.AddAsync(newInvoice);
        await _invoiceWriteRepository.SaveAsync();

        return new CreateInvoiceCommandResponse
        {
            IsSuccess = true
        };
    }
}