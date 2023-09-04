using Application.Repositories.House;
using MediatR;

namespace Application.Features.Commands.House.UpdateHouse;

public class UpdateHouseCommandHandler: IRequestHandler<UpdateHouseCommandRequest,UpdateHouseCommandResponse>
{
    private readonly IHouseWriterRepository _houseWriterRepository;

    public UpdateHouseCommandHandler(IHouseWriterRepository houseWriterRepository)
    {
        _houseWriterRepository = houseWriterRepository;
    }

    public async Task<UpdateHouseCommandResponse> Handle(UpdateHouseCommandRequest request, CancellationToken cancellationToken)
    {
        var house = await _houseWriterRepository.Table.FindAsync(request.Id);
        if (house == null)
            return new UpdateHouseCommandResponse()
            {
                IsSuccess = false
            };
        house.Status = request.Status;
        house.AppUserId = request.AppUserId;
        await _houseWriterRepository.SaveAsync();
        return new UpdateHouseCommandResponse
        {
            IsSuccess = true
        };
    }
}