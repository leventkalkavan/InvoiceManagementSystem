using Application.Abstractions.Services;
using Application.DTOs.UserDtos;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Persistence.Services;

public class UserService: IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
    {
        var result = await _userManager.CreateAsync(new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = model.Username,
            Email = model.Email,
            TC = model.TC,
            CarPlate = model.CarPlate,
            CreditCardBalance = model.CreditCardBalance,
            PhoneNumber = model.PhoneNumber,
            
        }, model.Password);
        CreateUserResponseDto response = new() { IsSuccess = result.Succeeded };
        return response;
    }

    public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate,
        int refreshTokenDate)
    {
        var appUser = await _userManager.FindByIdAsync(user.Id);
        if (appUser != null)
        {
            appUser.RefreshToken = refreshToken;
            appUser.RefreshTokenTime = accessTokenDate.AddSeconds(refreshTokenDate);
            await _userManager.UpdateAsync(appUser);
        }
        else
        {
            throw new Exception();
        }
    }
}