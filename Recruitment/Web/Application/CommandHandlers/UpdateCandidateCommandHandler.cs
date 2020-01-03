using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
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

            dbCandidate.UpdateName(request.Name);
            dbCandidate.UpdateBirthday(request.Birthday);
            dbCandidate.UpdateCurrentPosition(request.CurrentPosition);
            dbCandidate.UpdateNote(request.Note);

            _repo.Update(dbCandidate);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
