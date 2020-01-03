using MediatR;
using System;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetCandidateQuery : IRequest<CandidateModifyModel> 
    {
        public GetCandidateQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
