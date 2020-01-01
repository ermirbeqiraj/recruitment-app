using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class UpdateClientCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public UpdateClientCommand(Guid id, string name, string website, string description)
        {
            Id = id;
            Name = name;
            Website = website;
            Description = description;
        }
    }
}
