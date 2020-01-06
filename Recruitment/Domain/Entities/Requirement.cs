using Domain.Common;
using Domain.Constants;
using System;

namespace Domain.Entities
{
    public class Requirement : Entity
    {
        private const int CONTENT_LEN = 200;

        public SkillType SkillType { get; private set; }
        public RequirementType RequirementType { get; private set; }
        public string Content { get; private set; }

        private Requirement() { }
        public Requirement(string content, SkillType skillType, RequirementType requirementType) : this()
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));

            if (content.Length > CONTENT_LEN)
                throw new ArgumentOutOfRangeException(nameof(content), $"Length can't be more than {CONTENT_LEN}");

            Content = content;
            SkillType = skillType;
            RequirementType = requirementType;
        }

        public void UpdateSkillType(SkillType skillType) => SkillType = skillType;
        public void UpdateRequirementType(RequirementType requirementType) => RequirementType = requirementType;
        public void UpdateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));

            if (content.Length > CONTENT_LEN)
                throw new ArgumentOutOfRangeException(nameof(content), $"Length can't be more than {CONTENT_LEN}");

            Content = content;
        }
    }
}
