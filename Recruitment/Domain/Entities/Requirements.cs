using Domain.Common;
using Domain.Constants;

namespace Domain.Entities
{
    public class Requirements : Entity
    {
        public SkillType SkillType { get; private set; }
        public RequirementType RequirementType { get; private set; }
        public string Content { get; private set; }

        public Requirements(string content, SkillType skillType, RequirementType requirementType)
        {
            Content = content;
            SkillType = skillType;
            RequirementType = requirementType;
        }
    }
}
