using Application.Repositories.House;
using MediatR;

namespace Application.Features.Commands.House.DeleteHouse;

public class DeleteHouseCommandHandler: IRequestHandler<DeleteHouseCommandRequest,DeleteHouseCommandResponse>
{
    private readonly IHouseWriterRepository _houseWriterRepository;

    public DeleteHouseCommandHandler(IHouseWriterRepository houseWriterRepository)
    {
        _houseWriterRepository = houseWriterRepository;
    }

    public async Task<DeleteHouseCommandResponse> Handle(DeleteHouseCommandRequest request, CancellationToken cancellationToken)
    {
        await _houseWriterRepository.RemoveAsync(request.Id);
        await _houseWriterRepository.SaveAsync();
        return new DeleteHouseCommandResponse()
        {
            IsSuccess = true
        };
    }
}