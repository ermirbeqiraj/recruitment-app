using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using Domain.ValueObjects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, Result>
    {
        private readonly ICandidateRepository _repo;

        public UpdateCandidateCommandHandler(ICandidateRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var dbCandidate = await _repo.Get(request.Id);
            if (dbCandidate == null)
                return Result.Failure("Candidate not found!");

            var candidateName = new CandidateName(request.FirstName, request.LastName);

            dbCandidate.UpdateName(candidateName);
            dbCandidate.UpdateBirthday(request.Birthday);
            dbCandidate.UpdateCurrentPosition(request.CurrentPosition);
            dbCandidate.UpdateNote(request.Note);

            _repo.Update(dbCandidate);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
