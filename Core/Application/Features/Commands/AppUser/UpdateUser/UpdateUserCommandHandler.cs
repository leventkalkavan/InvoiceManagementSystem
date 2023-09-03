
using Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.UpdateUser;

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommandRequest,UpdateUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Authentication.AppUser> _userManager;

    public UpdateUserCommandHandler(UserManager<Domain.Entities.Authentication.AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        if (user == null)
            return new UpdateUserCommandResponse
            {
                IsSuccess = false
            };
        user.CreditCardBalance = request.CreditCardBalance;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;
        user.CarPlate = request.CarPlate;
        
        var result = await _userManager.UpdateAsync(user);
        UpdateUserCommandResponse response = new() { IsSuccess = result.Succeeded };
        return response;
    }
}