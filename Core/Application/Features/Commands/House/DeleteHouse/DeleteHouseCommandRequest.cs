using MediatR;

namespace Application.Features.Commands.House.DeleteHouse;

public class DeleteHouseCommandRequest: IRequest<DeleteHouseCommandResponse>
{
    public string Id { get; set; }
}