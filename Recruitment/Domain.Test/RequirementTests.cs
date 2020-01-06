using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.Test
{
    public class RequirementTests
    {
        [Fact]
        public void Should_Create_Requirement()
        {
            var content = "C# Expert";
            var requirement = new Requirement(content, SkillType.Technical, RequirementType.Required);

            Assert.Equal(content, requirement.Content);
            Assert.Equal(SkillType.Technical, requirement.SkillType);
            Assert.Equal(RequirementType.Required, requirement.RequirementType);
        }

        [Fact]
        public void Should_Throw_Null()
        {
            var content = "C# Expert";
            var req = new Requirement(content, SkillType.Soft, RequirementType.NiceToHave);

            Assert.Throws<ArgumentNullException>(() => req.UpdateContent(null));
            Assert.Throws<ArgumentNullException>(() => req.UpdateContent(""));
            Assert.Throws<ArgumentNullException>(() => req.UpdateContent("   "));
        }

        [Theory]
        [InlineData("C# Expert", SkillType.Technical, RequirementType.Required)]
        [InlineData("Team communication", SkillType.Soft, RequirementType.Required)]
        [InlineData("A bit of python", SkillType.Soft, RequirementType.NiceToHave)]
        public void Should_Create_From_Skill_And_Req_Type(string content, SkillType skillType, RequirementType requirementType)
        {
            var req = new Requirement(content, skillType, requirementType);

            Assert.Equal(content, req.Content);
            Assert.Equal(skillType, req.SkillType);
            Assert.Equal(requirementType, req.RequirementType);
        }
    }
}
