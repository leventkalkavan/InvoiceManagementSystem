using Domain.Entities.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.Role.AssigningRole;

public class AssigningRoleCommandHandler: IRequestHandler<AssigningRoleCommandRequest,AssigningRoleCommandResponse>
{
    private readonly UserManager<Domain.Entities.Authentication.AppUser> _userManager;
    private readonly RoleManager<Domain.Entities.Authentication.AppRole> _roleManager;

    public AssigningRoleCommandHandler(UserManager<Domain.Entities.Authentication.AppUser> userManager, RoleManager<Domain.Entities.Authentication.AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<AssigningRoleCommandResponse> Handle(AssigningRoleCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        var role = await _roleManager.FindByIdAsync(request.RoleId);

        if (user != null)
        {
            if (role != null)
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return new()
                    {
                        IsSuccess = true
                    };
                }
            }
        }
        return new ()
        {
            IsSuccess = false
        };
    }
}