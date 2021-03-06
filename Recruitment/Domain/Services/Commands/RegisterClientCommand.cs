﻿using CSharpFunctionalExtensions;
using MediatR;

namespace Domain.Services.Commands
{
    public sealed class RegisterClientCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public RegisterClientCommand(string name, string website, string description)
        {
            Name = name;
            Website = website;
            Description = description;
        }
    }
}
