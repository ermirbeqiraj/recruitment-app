using CSharpFunctionalExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Application.CommandHandlers
{
    public class MakeAppointmentCommandHandler : IRequestHandler<MakeAppointmentCommand, Result>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IClientRepository _clientRepository;

        public MakeAppointmentCommandHandler(IAppointmentRepository appointmentRepository, ICandidateRepository candidateRepository, IClientRepository clientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _candidateRepository = candidateRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(MakeAppointmentCommand request, CancellationToken cancellationToken)
        {
            var dbCandidate = await _candidateRepository.Get(request.CandidateId);
            if (dbCandidate == null)
                return Result.Failure("Candidate not found!");

            var dbVacancy = await _clientRepository.GetVacancy(request.VacancyId);
            if (dbVacancy == null)
                return Result.Failure("Vacancy not found!");


            var appointment = new Appointment(request.AppointmentType, request.StartsAt, dbCandidate, dbVacancy);
            _appointmentRepository.Add(appointment);
            await _appointmentRepository.UnitOfWork.SaveEntitiesAsync();

            return Result.Ok();
        }
    }
}
