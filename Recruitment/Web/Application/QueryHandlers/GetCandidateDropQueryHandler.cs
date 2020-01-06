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

namespace Web.Application.QueryHandlers
{
    public class GetCandidateDropQueryHandler : IRequestHandler<GetCandidateDropQuery, List<DropModel>>
    {
        private readonly ConnectionString _connectionString;

        public GetCandidateDropQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<DropModel>> Handle(GetCandidateDropQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, CandidateName_FirstName + ' ' + CandidateName_LastName as [Text] from Candidates";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.QueryAsync<DropModel>(sql);
                return result.ToList();
            }
        }
    }
}
