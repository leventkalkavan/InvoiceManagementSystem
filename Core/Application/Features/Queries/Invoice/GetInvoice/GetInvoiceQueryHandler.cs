using Application.DTOs.InvoiceDto;
using Application.DTOs.UserDtos;
using Application.Features.Queries.House;
using Application.Repositories.Invoice;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Invoice;

public class GetInvoiceQueryHandler: IRequestHandler<GetInvoiceQueryRequest,GetInvoiceQueryResponse>
{
    private readonly IInvoiceReadRepository _ınvoiceReadRepository;

    public GetInvoiceQueryHandler(IInvoiceReadRepository ınvoiceReadRepository)
    {
        _ınvoiceReadRepository = ınvoiceReadRepository;
    }

    public async Task<GetInvoiceQueryResponse> Handle(GetInvoiceQueryRequest request, CancellationToken cancellationToken)
    { 
        var invoices = _ınvoiceReadRepository.Table
            .ToList();

        var response = new GetInvoiceQueryResponse()
        {
            Invoices = invoices.Select(invoice => new InvoiceDto()
            {
                Id = invoice.Id,
                Name = invoice.Name,
                Bill = invoice.Bill.ToString(),
                IsPaid = invoice.IsPaid,
                CreatedDate = invoice.CreatedDate,
                LastPaymentDate = invoice.LastPaymentDate
            }).ToList()
        };
        return response;
    }
}