using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public class UpdateVacancyCommandHandler : IRequestHandler<UpdateVacancyCommand, Result>
    {
        private readonly IClientRepository _repo;
        public UpdateVacancyCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(UpdateVacancyCommand request, CancellationToken cancellationToken)
        {
            var dbClient = await _repo.Get(request.ClientId);
            if (dbClient == null)
                return Result.Failure("Failed to retrieve client of this vacancy");

            var dbVacancy = dbClient.Vacancies.Where(x => x.Id == request.Id).FirstOrDefault();
            if (dbVacancy == null)
                return Result.Failure("Unable to find current vacancy");

            dbClient.UpdateVacancy(dbVacancy, request.Title, request.Description, request.OpenDate, request.CloseDate);

            _repo.Update(dbClient);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
