using Application.Repositories.House;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.House;

public class HouseReadRepository: ReadRepository<Domain.Entities.House>, IHouseReadRepository
{
    public HouseReadRepository(AppDbContext context) : base(context)
    {
    }
}