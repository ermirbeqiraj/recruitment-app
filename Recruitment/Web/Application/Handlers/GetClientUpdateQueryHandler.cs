using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Web.Application.Queries;
using Web.Models;
using Web.Utils;

namespace Web.Application.Handlers
{
    public sealed class GetClientUpdateQueryHandler : IRequestHandler<GetClientUpdateQuery, ClientUpdateModel>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetClientUpdateQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ClientUpdateModel> Handle(GetClientUpdateQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"select C.Id, C.Name, C.Website, C.Description from Clients as C where C.Id = @ClientId";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var dbItem = await connection.QueryFirstOrDefaultAsync<ClientUpdateModel>(sql, new { request.ClientId });
                return dbItem;
            }
        }
    }
}
