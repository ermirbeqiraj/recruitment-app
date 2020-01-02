using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Linq;
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
            var dbClient = await _repo.Get(request.ClientId);
            if (dbClient == null)
                return Result.Failure("Failed to retrieve client");

            var dbVacancy = dbClient.Vacancies.Where(x => x.Id == request.VacancyId).FirstOrDefault();
            if (dbVacancy == null)
                return Result.Failure("Failed to retrieve vacancy");

            var dbRequirement = dbClient.Vacancies.SelectMany(x => x.Requirements).Where(x => x.Id == request.Id).FirstOrDefault();
            if (dbRequirement == null)
                return Result.Failure("Failed to retrieve requirement");
            
            dbClient.UpdateRequirement(dbVacancy, dbRequirement, new Requirement(request.Content, request.SkillType, request.RequirementType));

            _repo.Update(dbClient);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
