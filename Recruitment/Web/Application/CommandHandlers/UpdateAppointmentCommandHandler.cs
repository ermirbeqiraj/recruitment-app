using CSharpFunctionalExtensions;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Result>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IClientRepository _clientRepository;

        public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, ICandidateRepository candidateRepository, IClientRepository clientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _candidateRepository = candidateRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var dbAppointment = await _appointmentRepository.Get(request.Id);
            if (dbAppointment == null)
                return Result.Failure("Appointment not found");

            var dbCandidate = await _candidateRepository.Get(request.CandidateId);
            if (dbCandidate == null)
                return Result.Failure("Candidate not found!");

            var dbVacancy = await _clientRepository.GetVacancy(request.VacancyId);
            if (dbVacancy == null)
                return Result.Failure("Vacancy not found!");


            dbAppointment.UpdateAppointmentType(request.AppointmentType);
            dbAppointment.UpdateCandidate(dbCandidate);
            dbAppointment.UpdateVacancy(dbVacancy);
            dbAppointment.UpdateStartsAt(request.StartsAt);

            _appointmentRepository.Update(dbAppointment);
            await _appointmentRepository.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
