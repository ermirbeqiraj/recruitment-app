using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
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
            _repo.Add(new Domain.Entities.Candidate(request.Name, request.Birthday, request.CurrentPosition, request.Note));
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
