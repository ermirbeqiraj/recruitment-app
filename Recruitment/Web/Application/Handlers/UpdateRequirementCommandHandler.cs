using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class UpdateRequirementCommandHandler : IRequestHandler<UpdateRequirementCommand, Result>
    {
        private readonly IClientRepository _repo;

        public UpdateRequirementCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(UpdateRequirementCommand request, CancellationToken cancellationToken)
        {
            var client = await _repo.Get(request.ClientId);
            if (client == null)
                return Result.Failure("Failed to retrieve client");

            client.UpdateRequirements(request.VacancyId, request.Id, request.Content, request.SkillType, request.RequirementType);

            _repo.Update(client);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
