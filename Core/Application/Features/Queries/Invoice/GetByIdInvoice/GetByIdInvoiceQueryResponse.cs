using MediatR;

namespace Application.Features.Queries.Invoice.GetByIdInvoice;

public class GetByIdInvoiceQueryResponse
{
    public string Name { get; set; }
    public decimal? Bill { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastPaymentDate { get; set; }
    public string HouseId { get; set; }
}