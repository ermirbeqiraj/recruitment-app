using CSharpFunctionalExtensions;
using Domain.Constants;
using MediatR;
using System;

namespace Domain.Services.Commands
{
    public sealed class AddRequirementCommand : IRequest<Result>
    {
        public AddRequirementCommand(Guid vacancyId, Guid clientId, SkillType skillType, RequirementType requirementType, string content)
        {
            VacancyId = vacancyId;
            ClientId = clientId;
            SkillType = skillType;
            RequirementType = requirementType;
            Content = content;
        }

        public Guid VacancyId { get; set; }
        public Guid ClientId { get; set; }
        public SkillType SkillType { get; set; }
        public RequirementType RequirementType { get; set; }
        public string Content { get; set; }
    }
}
