using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Application.Queries;
using Web.Models;
using Web.Utils;

namespace Web.Application.Handlers
{
    public sealed class GetClientsCommandHandler : IRequestHandler<GetClientsCommand, List<ClientListModel>>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetClientsCommandHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ClientListModel>> Handle(GetClientsCommand request, CancellationToken cancellationToken)
        {
            const string sql = @"select C.Id, C.Name, C.Website, C.Description, Count(V.Id) as OpenVacancies
                                    from Clients as C
                                    left join Vacancies as V on C.Id = V.ClientId
                                    group by C.Id, C.Name, C.Website, C.Description";


            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var dbItems = await connection.QueryAsync<ClientListModel>(sql);
                return dbItems.ToList();
            }
        }
    }
}
