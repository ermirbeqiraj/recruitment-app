using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public class RegisterCandidateCommandHandler : IRequestHandler<RegisterCandidateCommand, Result>
    {
        private readonly ICandidateRepository _repo;

        public RegisterCandidateCommandHandler(ICandidateRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(RegisterCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidateName = new CandidateName(request.FirstName, request.LastName);

            _repo.Add(new Domain.Entities.Candidate(candidateName, request.Birthday, request.CurrentPosition, request.Note));
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
