using Domain.Entities.Authentication;

namespace Application.Abstractions.Services;

public interface IAuthService
{
    Task<DTOs.TokenDto.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    Task<DTOs.TokenDto.Token> RefreshTokenLoginAsync(string refreshToken);
}