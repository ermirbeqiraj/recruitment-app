using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class RemoveRequirementCommandHandler : IRequestHandler<RemoveRequirementCommand, Result>
    {
        private readonly IClientRepository _repo;

        public RemoveRequirementCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(RemoveRequirementCommand request, CancellationToken cancellationToken)
        {
            var client = await _repo.Get(request.ClientId);
            if (client == null)
                return Result.Failure("Failed to retrieve client");

            client.RemoveRequirement(request.VacancyId, request.Id);

            _repo.Update(client);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
