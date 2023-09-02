using Application.DTOs.UserDtos;
using Application.Features.Commands.AppUser.CreateUser;
using Application.Repositories;
using Domain.Entities;
using Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
}