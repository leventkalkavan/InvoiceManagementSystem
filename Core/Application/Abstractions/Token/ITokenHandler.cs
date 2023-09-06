using Domain.Entities.Authentication;

namespace Application.Abstractions.Token;

public interface ITokenHandler
{
    DTOs.TokenDto.Token CreateAccessToken(int second,AppUser user);
    string CreateRefreshToken();
}