using Domain.Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Role;

public class CreateRoleCommandHandler: IRequestHandler<CreateRoleCommandRequest,CreateRoleCommandResponse>
{
    private readonly RoleManager<Domain.Entities.Authentication.AppRole> _roleManager;

    public CreateRoleCommandHandler(RoleManager<Domain.Entities.Authentication.AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        IdentityResult result = await _roleManager.CreateAsync(new Domain.Entities.Authentication.AppRole { Name = request.Name, CreatedDate = DateTime.Now });
        if (result.Succeeded)
        {
            return new CreateRoleCommandResponse
            {
                IsSuccess = true
            };
        }

        return new CreateRoleCommandResponse
        {
            IsSuccess = false
        };
    }
}