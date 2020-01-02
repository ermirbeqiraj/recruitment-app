using Domain.Common;
using Domain.Constants;

namespace Domain.Entities
{
    public class Requirement : Entity
    {
        public SkillType SkillType { get; private set; }
        public RequirementType RequirementType { get; private set; }
        public string Content { get; private set; }

        private Requirement() { }
        public Requirement(string content, SkillType skillType, RequirementType requirementType) : this()
        {
            Content = content;
            SkillType = skillType;
            RequirementType = requirementType;
        }

        public void UpdateSkillType(SkillType skillType) => SkillType = skillType;
        public void UpdateRequirementType(RequirementType requirementType) => RequirementType = requirementType;
        public void UpdateContent(string content) => Content = content;
    }
}
