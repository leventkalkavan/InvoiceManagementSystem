using Application.DTOs.RoleDto;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.AppRole;

public class AppRoleQueryHandler: IRequestHandler<AppRoleQueryRequest,AppRoleQueryResponse>
{
    private readonly RoleManager<Domain.Entities.Authentication.AppRole> _roleManager;

    public AppRoleQueryHandler(RoleManager<Domain.Entities.Authentication.AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<AppRoleQueryResponse> Handle(AppRoleQueryRequest request, CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var response = new AppRoleQueryResponse()
        {
            Roles = roles.Select(role => new RoleDto()
            {
                Id = role.Id,
                Name = role.Name,
                CreatedDate = role.CreatedDate
            }).ToList()
        };
        return response;
    }
}