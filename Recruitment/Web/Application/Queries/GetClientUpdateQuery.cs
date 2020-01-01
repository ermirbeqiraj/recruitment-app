using MediatR;
using System;
using Web.Models;

namespace Web.Application.Queries
{
    public sealed class GetClientUpdateQuery : IRequest<ClientUpdateModel>
    {
        public Guid ClientId { get; set; }
        public GetClientUpdateQuery(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
