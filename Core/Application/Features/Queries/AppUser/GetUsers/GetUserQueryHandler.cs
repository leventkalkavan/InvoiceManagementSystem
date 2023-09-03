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
                Username = user.UserName,
                TC = user.TC,
                Email = user.Email,
                CreditCardBalance = user.CreditCardBalance,
                PhoneNumber = user.PhoneNumber,
                CarPlate = user.CarPlate
            }).ToList()
        };

        return response;
    }
}