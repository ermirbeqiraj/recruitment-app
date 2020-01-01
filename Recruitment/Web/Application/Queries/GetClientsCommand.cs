using MediatR;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetClientsCommand : IRequest<List<ClientListModel>> { }
}
