using Application.Repositories.House;
using MediatR;

namespace Application.Features.Commands.House.CreateHouse;

public class CreateHouseCommandHandler: IRequestHandler<CreateHouseCommandRequest,CreateHouseCommandResponse>
{
    private readonly IHouseWriterRepository _houseWriterRepository;

    public CreateHouseCommandHandler(IHouseWriterRepository houseWriterRepository)
    {
        _houseWriterRepository = houseWriterRepository;
    }

    public async Task<CreateHouseCommandResponse> Handle(CreateHouseCommandRequest request, CancellationToken cancellationToken)
    {
        await _houseWriterRepository.AddAsync(new Domain.Entities.House
        {
            Status = request.Status,
            Type = request.Type,
            Block = request.Block,
            ApartmentNumber = request.ApartmentNumber,
            Floor = request.Floor,
            AppUserId = request.UserId
        });
        await _houseWriterRepository.SaveAsync();
        return new CreateHouseCommandResponse
        {
            IsSuccess = true
        };
    }
}