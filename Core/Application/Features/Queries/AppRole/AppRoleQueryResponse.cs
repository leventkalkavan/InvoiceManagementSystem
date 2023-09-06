using Application.DTOs.RoleDto;
using MediatR;

namespace Application.Features.Queries.AppRole;

public class AppRoleQueryResponse
{
    public List<RoleDto> Roles { get; set; }
}