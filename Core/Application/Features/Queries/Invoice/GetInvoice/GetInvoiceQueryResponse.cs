using Application.DTOs.InvoiceDto;

namespace Application.Features.Queries.Invoice;

public class GetInvoiceQueryResponse
{
   public List<InvoiceDto> Invoices { get; set; }
}