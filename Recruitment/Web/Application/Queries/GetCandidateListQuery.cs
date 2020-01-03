using MediatR;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetCandidateListQuery : IRequest<List<CandidateListModel>> { }
}
