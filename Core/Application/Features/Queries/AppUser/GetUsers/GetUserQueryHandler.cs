using Application.DTOs.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.AppUser.GetUsers;

public class GetUserQueryHandler: IRequestHandler<GetUserQueryRequest,GetUserQueryResponse>
{
    private readonly UserManager<Domain.Entities.Authentication.AppUser> _userManager;

    public GetUserQueryHandler(UserManager<Domain.Entities.Authentication.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.ToListAsync();
        var response = new GetUserQueryResponse
        {
            Users = users.Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email
            }).ToList()
        };

        return response;
    }
}