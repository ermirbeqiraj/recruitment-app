using MediatR;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetRequirementListQuery : IRequest<List<RequirementListModel>>
    {
        public GetRequirementListQuery(Guid vacancyId)
        {
            VacancyId = vacancyId;
        }

        public Guid VacancyId { get; set; }
    }
}
