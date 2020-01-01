using MediatR;
using System;
using Web.Models;

namespace Web.Application.Queries
{
    public class GetVacancyQuery : IRequest<VacancyUpdateModel>
    {
        public GetVacancyQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
