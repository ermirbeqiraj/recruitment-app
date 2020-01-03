using MediatR;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public class GetCandidateDropQuery : IRequest<List<DropModel>> { }
}
