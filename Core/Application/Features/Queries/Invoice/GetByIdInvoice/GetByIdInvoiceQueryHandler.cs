using Application.DTOs.InvoiceDto;
using Application.Repositories.Invoice;
using MediatR;

namespace Application.Features.Queries.Invoice.GetByIdInvoice
{
    public class GetByIdInvoiceQueryHandler : IRequestHandler<GetByIdInvoiceQueryRequest, GetByIdInvoiceQueryResponse>
    {
        private readonly IInvoiceReadRepository _ınvoiceReadRepository;

        public GetByIdInvoiceQueryHandler(IInvoiceReadRepository ınvoiceReadRepository)
        {
            _ınvoiceReadRepository = ınvoiceReadRepository;
        }

        public async Task<GetByIdInvoiceQueryResponse> Handle(GetByIdInvoiceQueryRequest request, CancellationToken cancellationToken)
        {
            var invoice = await _ınvoiceReadRepository.GetByIdAsync(request.Id, false);
            return new GetByIdInvoiceQueryResponse()
            {
                HouseId = invoice.HouseId,
                Name = invoice.Name,
                Bill = invoice.Bill,
                IsPaid = invoice.IsPaid,
                CreatedDate = invoice.CreatedDate,
                LastPaymentDate = invoice.LastPaymentDate
            };
        }
    }
}