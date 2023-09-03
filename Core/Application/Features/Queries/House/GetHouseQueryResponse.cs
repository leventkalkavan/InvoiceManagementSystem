using Application.DTOs.UserDtos;

namespace Application.Features.Queries.House;

public class GetHouseQueryResponse
{
    public List<HouseDto> Houses { get; set; }
}