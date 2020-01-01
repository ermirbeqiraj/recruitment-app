using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, Result>
    {
        private readonly IClientRepository _repo;
        public RegisterClientCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name, request.Website, request.Description);
            _repo.Add(client);

            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
