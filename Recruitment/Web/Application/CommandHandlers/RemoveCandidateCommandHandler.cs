using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public class RemoveCandidateCommandHandler : IRequestHandler<RemoveCandidateCommand, Result>
    {
        private readonly ICandidateRepository _repo;

        public RemoveCandidateCommandHandler(ICandidateRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(RemoveCandidateCommand request, CancellationToken cancellationToken)
        {
            var dbCandidate = await _repo.Get(request.Id);
            if (dbCandidate == null)
                return Result.Failure("Candidate not found");

            _repo.Remove(dbCandidate);
            await _repo.UnitOfWork.SaveEntitiesAsync();
            return Result.Ok();
        }
    }
}
