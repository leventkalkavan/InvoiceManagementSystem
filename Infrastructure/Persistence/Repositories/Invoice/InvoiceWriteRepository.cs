using Application.Repositories.Invoice;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Invoice;

public class InvoiceWriteRepository: WriteRepository<Domain.Entities.Invoice>, IInvoiceWriteRepository
{
    public InvoiceWriteRepository(AppDbContext context) : base(context)
    {
    }
}