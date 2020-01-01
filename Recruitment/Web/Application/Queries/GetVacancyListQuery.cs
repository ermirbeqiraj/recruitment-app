using MediatR;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetVacancyListQuery : IRequest<List<VacancyListModel>>
    {
        public Guid ClientId { get; set; }
        public GetVacancyListQuery(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
