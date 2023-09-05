using MediatR;

namespace Application.Features.Queries.Invoice;

public class GetInvoiceQueryRequest: IRequest<GetInvoiceQueryResponse>
{
    public string Id { get; set; }
}