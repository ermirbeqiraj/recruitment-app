using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
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
            var dbClient = await _repo.Get(request.ClientId);
            if (dbClient == null)
                return Result.Failure("Failed to retrieve client");

            var dbVacancy = dbClient.Vacancies.Where(x => x.Id == request.VacancyId).FirstOrDefault();
            if (dbVacancy == null)
                return Result.Failure("Failed to retrieve vacancy");

            var requirement = new Requirement(request.Content, request.SkillType, request.RequirementType);

            dbClient.AddRequirementOnVacancy(dbVacancy, requirement);

            _repo.Update(dbClient);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
