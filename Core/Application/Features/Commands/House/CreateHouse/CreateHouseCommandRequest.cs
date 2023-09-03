using MediatR;

namespace Application.Features.Commands.House;

public class CreateHouseCommandRequest: IRequest<CreateHouseCommandResponse>
{
    public string UserId { get; set; }
    public bool Status { get; set; }
    public string Type { get; set; }
    public string Block { get; set; }
    public int ApartmentNumber { get; set; }
    public int Floor { get; set; }
}