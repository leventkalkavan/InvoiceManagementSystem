using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Application.DTOs.UserDtos;

public class HouseDto
{
    public string Id { get; set; }
    public bool Status { get; set; }
    public string Type { get; set; }
    public string Block { get; set; }
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
    public string AppUserId { get; set; }
    public List<InvoiceDto.InvoiceDto> Invoices { get; set; }
}