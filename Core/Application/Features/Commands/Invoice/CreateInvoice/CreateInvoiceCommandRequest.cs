using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Application.Features.Commands.Invoice.CreateInvoice;

public class CreateInvoiceCommandRequest : IRequest<CreateInvoiceCommandResponse>
{
    public string HouseId { get; set; }
    public string Name { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Bill { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreatedDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastPaymentDate { get; set; }
}