using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public sealed class CloseVacancyCommandHandler : IRequestHandler<CloseVacancyCommand, Result>
    {
        private readonly IClientRepository _repo;

        public CloseVacancyCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(CloseVacancyCommand request, CancellationToken cancellationToken)
        {
            var client = await _repo.Get(request.ClientId);
            if (client == null)
                return Result.Failure("Failed to retrieve client of this vacancy");

            var searchingVacancy = client.Vacancies.Where(x => x.Id == request.Id).FirstOrDefault();
            if (searchingVacancy == null)
                return Result.Failure("Unable to find current vacancy");

            client.CloseVacancy(searchingVacancy);

            _repo.Update(client);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
