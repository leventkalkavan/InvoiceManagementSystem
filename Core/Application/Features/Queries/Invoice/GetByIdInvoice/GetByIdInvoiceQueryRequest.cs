using MediatR;

namespace Application.Features.Queries.Invoice.GetByIdInvoice;

public class GetByIdInvoiceQueryRequest: IRequest<GetByIdInvoiceQueryResponse>
{
    public string Id { get; set; }
}