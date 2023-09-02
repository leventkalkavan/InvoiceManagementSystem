using Application.DTOs.UserDtos;

namespace Application.Features.Queries.AppUser.GetUsers;

public class GetUserQueryResponse
{
    public List<UserDto> Users { get; set; }
}