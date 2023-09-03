using Application.DTOs.UserDtos;
using Application.Repositories.House;
using MediatR;

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
        var houses =   _houseReadRepository.GetAll().ToList();
        var response = new GetHouseQueryResponse()
        {
            Houses = houses.Select(houses => new HouseDto()
            {
                Id = houses.Id,
                Status = houses.Status,
                Type = houses.Type,
                Block = houses.Block,
                ApartmentNumber = houses.ApartmentNumber,
                Floor = houses.Floor,
                AppUserId = houses.AppUserId
            }).ToList()
        };

        return response;
    }
}