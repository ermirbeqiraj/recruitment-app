using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class OpenVacancyCommandHandler : IRequestHandler<OpenVacancyCommand, Result>
    {
        private readonly IClientRepository _repo;

        public OpenVacancyCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(OpenVacancyCommand request, CancellationToken cancellationToken)
        {
            var dbClient = await _repo.Get(request.ClientId);

            if (dbClient == null)
                return Result.Failure("Not able to find the specified client");

            var vacancy = new Vacancy(request.Title, request.Description, request.OpenDate, request.CloseDate);
            dbClient.AddVacancy(vacancy);
            _repo.Update(dbClient);

            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
