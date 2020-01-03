using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class RemoveAppointmentCommand : IRequest<Result>
    {
        public RemoveAppointmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
