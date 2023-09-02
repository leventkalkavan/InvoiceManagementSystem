using Application.Repositories.House;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.House;

public class HouseWriteRepository: WriteRepository<Domain.Entities.House>, IHouseWriterRepository
{
    public HouseWriteRepository(AppDbContext context) : base(context)
    {
    }
}