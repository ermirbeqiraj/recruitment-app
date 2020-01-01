using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.Handlers
{
    public sealed class RegisterClientCommandHandler : AsyncRequestHandler<RegisterClientCommand>
    {
        private readonly IClientRepository _repo;
        public RegisterClientCommandHandler(IClientRepository repo)
        {
            _repo = repo;
        }

        protected override async Task Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name, request.Website, request.Description);

            var now = DateTime.Now;
            var vacancy = new Vacancy(".Net backend developer", "Senior", now, now.AddMonths(1));
            vacancy.AddRequirement(new Requirement("Sharp", Domain.Constants.SkillType.Technical, Domain.Constants.RequirementType.NiceToHave));

            client.AddVacancy(vacancy);

            _repo.Add(client);
            await _repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
