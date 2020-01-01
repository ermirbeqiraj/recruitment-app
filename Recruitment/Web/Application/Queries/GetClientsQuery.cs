using MediatR;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetClientsQuery : IRequest<List<ClientListModel>> { }
}
