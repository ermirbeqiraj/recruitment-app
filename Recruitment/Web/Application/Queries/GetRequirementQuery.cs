using MediatR;
using System;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetRequirementQuery : IRequest<RequirementUpdateModel>
    {
        public GetRequirementQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
