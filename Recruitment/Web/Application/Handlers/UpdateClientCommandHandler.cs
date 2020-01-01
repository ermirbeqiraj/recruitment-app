using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result>
    {
        private readonly IClientRepository _repo;
        public UpdateClientCommandHandler(IClientRepository repository)
        {
            _repo = repository;
        }

        public async Task<Result> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var dbClient = await _repo.Get(request.Id);

            if (dbClient == null)
                return Result.Failure("Not able to find this client");

            dbClient.UpdateName(request.Name);
            dbClient.UpdateWebsite(request.Website);
            dbClient.UpdateDescription(request.Description);

            _repo.Update(dbClient);

            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
