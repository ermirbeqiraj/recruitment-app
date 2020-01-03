using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public class RemoveAppointmentCommandHandler : IRequestHandler<RemoveAppointmentCommand, Result>
    {
        private readonly IAppointmentRepository _repo;

        public RemoveAppointmentCommandHandler(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(RemoveAppointmentCommand request, CancellationToken cancellationToken)
        {
            var dbAppointment = await _repo.Get(request.Id);
            if (dbAppointment == null)
                return Result.Failure("Appointment not found");

            _repo.Remove(dbAppointment);
            await _repo.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
