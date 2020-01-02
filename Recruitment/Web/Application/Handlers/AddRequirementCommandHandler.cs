using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class AddRequirementCommandHandler : IRequestHandler<AddRequirementCommand, Result>
    {
        private readonly IClientRepository _repo;

        public AddRequirementCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(AddRequirementCommand request, CancellationToken cancellationToken)
        {
            var client = await _repo.GetByVacancy(request.VacancyId);
            if (client == null)
                return Result.Failure("Failed to retrieve client");

            client.AddRequirementOnVacancy(request.VacancyId, request.Content, request.SkillType, request.RequirementType);

            _repo.Update(client);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
