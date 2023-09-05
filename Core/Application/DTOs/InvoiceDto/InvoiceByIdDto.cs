namespace Application.DTOs.InvoiceDto;

public class InvoiceByIdDto
{
    public string Name { get; set; }
    public decimal? Bill { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastPaymentDate { get; set; }
}