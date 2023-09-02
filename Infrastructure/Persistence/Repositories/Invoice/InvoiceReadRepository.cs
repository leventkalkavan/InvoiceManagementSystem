using Application.Repositories.Invoice;
using Persistence.Context;

namespace Persistence.Repositories.Invoice;

public class InvoiceReadRepository: ReadRepository<Domain.Entities.Invoice>, IInvoiceReadRepository
{
    public InvoiceReadRepository(AppDbContext context) : base(context)
    {
    }
}