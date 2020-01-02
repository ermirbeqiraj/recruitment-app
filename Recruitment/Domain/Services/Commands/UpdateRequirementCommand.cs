using CSharpFunctionalExtensions;
using Domain.Constants;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class UpdateRequirementCommand : IRequest<Result>
    {
        public UpdateRequirementCommand(Guid id, Guid vacancyId, Guid clientId, SkillType skillType, RequirementType requirementType, string content)
        {
            Id = id;
            VacancyId = vacancyId;
            ClientId = clientId;
            SkillType = skillType;
            RequirementType = requirementType;
            Content = content;
        }

        public Guid Id { get; set; }
        public Guid VacancyId { get; set; }
        public Guid ClientId { get; set; }
        public SkillType SkillType { get; set; }
        public RequirementType RequirementType { get; set; }
        public string Content { get; set; }
    }
}
