using MediatR;

namespace Application.Features.Commands.House.DeleteHouse;

public class DeleteHouseCommandResponse
{
    public bool IsSuccess { get; set; }
}