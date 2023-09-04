namespace Application.DTOs.InvoiceDto;

public class InvoiceDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Bill { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastPaymentDate { get; set; }
}