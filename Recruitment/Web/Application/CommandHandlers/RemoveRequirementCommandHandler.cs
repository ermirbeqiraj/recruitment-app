using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
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
            var dbClient = await _repo.Get(request.ClientId);
            if (dbClient == null)
                return Result.Failure("Failed to retrieve client");

            var dbRequirement = dbClient.Vacancies.SelectMany(x => x.Requirements).Where(x => x.Id == request.Id).FirstOrDefault();
            if (dbRequirement == null)
                return Result.Failure("Failed to retrieve requirement");

            dbClient.RemoveRequirement(dbRequirement);
            _repo.Update(dbClient);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
