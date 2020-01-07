using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Domain.Test
{
    public class VacancyTests
    {
        [Fact]
        public void Should_Create_Vacancy()
        {
            var vacancyData = new { Title = "C# Developer", Description = "Preffered with side ruby history", OpenDate = DateTime.Now, CloseDate = DateTime.Now.AddMonths(1) };
            var vacancy = new Vacancy(vacancyData.Title, vacancyData.Description, vacancyData.OpenDate, vacancyData.CloseDate);

            Assert.Equal(vacancyData.Title, vacancy.Title);
            Assert.Equal(vacancyData.Description, vacancy.Description);
            Assert.Equal(vacancyData.OpenDate, vacancy.OpenDate);
            Assert.Equal(vacancyData.CloseDate, vacancy.CloseDate);
            Assert.NotNull(vacancy.Requirements);
            Assert.Empty(vacancy.Requirements);
        }

        [Fact]
        public void Should_Update_Vacancy()
        {
            var createData = new { Title = "C# Developer", Description = "Preffered with side ruby history", OpenDate = DateTime.Now, CloseDate = DateTime.Now.AddMonths(1) };
            var updateData = new { Title = ".Net Developer", Description = "Preffered with side python history", OpenDate = DateTime.Now.AddMonths(1), CloseDate = DateTime.Now.AddMonths(3) };

            var vacancy = new Vacancy(createData.Title, createData.Description, createData.OpenDate, createData.CloseDate);
            vacancy.UpdateTitle(updateData.Title);
            vacancy.UpdateDescription(updateData.Description);
            vacancy.UpdateCloseDate(updateData.CloseDate);
            vacancy.UpdateOpenDate(updateData.OpenDate);


            Assert.Equal(updateData.Title, vacancy.Title);
            Assert.Equal(updateData.Description, vacancy.Description);
            Assert.Equal(updateData.OpenDate, vacancy.OpenDate);
            Assert.Equal(updateData.CloseDate, vacancy.CloseDate);
            Assert.NotNull(vacancy.Requirements);
            Assert.Empty(vacancy.Requirements);
        }

        [Fact]
        public void Should_Add_Requirement()
        {
            var vacancyData = new { Title = "C# Developer", Description = "Preffered with side ruby history", OpenDate = DateTime.Now, CloseDate = DateTime.Now.AddMonths(1) };
            var requirementData = new { SkillType = SkillType.Technical, RequirementType = RequirementType.NiceToHave, Content = "Python" };

            var vacancy = new Vacancy(vacancyData.Title, vacancyData.Description, vacancyData.OpenDate, vacancyData.CloseDate);
            vacancy.AddRequirement(new Requirement(requirementData.Content, requirementData.SkillType, requirementData.RequirementType));

            Assert.Equal(1, vacancy.Requirements.Count);
        }

        [Fact]
        public void Should_Remove_Requirement()
        {
            var vacancyData = new { Title = "C# Developer", Description = "Preffered with side ruby history", OpenDate = DateTime.Now, CloseDate = DateTime.Now.AddMonths(1) };
            var requirementData = new { SkillType = SkillType.Technical, RequirementType = RequirementType.NiceToHave, Content = "Python" };

            var vacancy = new Vacancy(vacancyData.Title, vacancyData.Description, vacancyData.OpenDate, vacancyData.CloseDate);
            vacancy.AddRequirement(new Requirement(requirementData.Content, requirementData.SkillType, requirementData.RequirementType));

            var requirement = vacancy.Requirements.FirstOrDefault();
            vacancy.RemoveRequirement(requirement);

            Assert.NotNull(requirement);
            Assert.Empty(vacancy.Requirements);
        }

        [Fact]
        public void Should_Update_Requirement()
        {
            var vacancyData = new { Title = "C# Developer", Description = "Preffered with side ruby history", OpenDate = DateTime.Now, CloseDate = DateTime.Now.AddMonths(1) };
            var requirementData = new { SkillType = SkillType.Technical, RequirementType = RequirementType.NiceToHave, Content = "Python" };
            var requirementUpdateData = new { SkillType = SkillType.Technical, RequirementType = RequirementType.NiceToHave, Content = "Python" };

            var vacancy = new Vacancy(vacancyData.Title, vacancyData.Description, vacancyData.OpenDate, vacancyData.CloseDate);
            vacancy.AddRequirement(new Requirement(requirementData.Content, requirementData.SkillType, requirementData.RequirementType));
            
            var requirement = vacancy.Requirements.FirstOrDefault();
            var newRequirement = new Requirement(requirementUpdateData.Content, requirement.SkillType, requirementUpdateData.RequirementType);
            vacancy.UpdateRequirement(requirement, newRequirement);
            requirement = vacancy.Requirements.FirstOrDefault();

            Assert.NotEmpty(vacancy.Requirements);
            Assert.NotNull(requirement);
            Assert.Equal(newRequirement.Content, requirement.Content);
            Assert.Equal(newRequirement.SkillType, requirement.SkillType);
            Assert.Equal(newRequirement.RequirementType, requirement.RequirementType);
        }
    }
}
