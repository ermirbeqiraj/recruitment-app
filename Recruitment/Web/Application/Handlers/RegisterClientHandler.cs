using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class RegisterClientHandler : AsyncRequestHandler<RegisterClientCommand>
    {
        private readonly IClientRepository _repo;
        public RegisterClientHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        protected override async Task Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name, request.Website, request.Description);
            _repo.Add(client);
            await _repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
