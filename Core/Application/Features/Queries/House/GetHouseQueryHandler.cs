using Application.DTOs.InvoiceDto;
using Application.DTOs.UserDtos;
using Application.Repositories.House;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.House;

public class GetHouseQueryHandler: IRequestHandler<GetHouseQueryRequest,GetHouseQueryResponse>
{
    private readonly IHouseReadRepository _houseReadRepository;

    public GetHouseQueryHandler(IHouseReadRepository houseReadRepository)
    {
        _houseReadRepository = houseReadRepository;
    }

    public async Task<GetHouseQueryResponse> Handle(GetHouseQueryRequest request, CancellationToken cancellationToken)
    {
        var houses = _houseReadRepository.Table.Include(h => h.Invoices)
            .ToList();

        var response = new GetHouseQueryResponse()
        {
            Houses = houses.Select(house => new HouseDto()
            {
                Id = house.Id,
                Status = house.Status,
                Type = house.Type,
                Block = house.Block,
                ApartmentNumber = house.ApartmentNumber,
                Floor = house.Floor,
                AppUserId = house.AppUserId,
                Invoices = house.Invoices.Select(invoice => new InvoiceDto()
                {
                    Id = invoice.Id,
                    Name = invoice.Name,
                    Bill = invoice.Bill.ToString(),
                    IsPaid = !invoice.IsPaid,
                    CreatedDate = invoice.CreatedDate,
                    LastPaymentDate = invoice.LastPaymentDate
                }).ToList()
            }).ToList()
        };


        return response;
    }
}