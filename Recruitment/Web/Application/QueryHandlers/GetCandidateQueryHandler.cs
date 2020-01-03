using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Web.Application.Queries;
using Web.Models;
using Web.Utils;

namespace Web.Application.QueryHandlers
{
    public class GetCandidateQueryHandler : IRequestHandler<GetCandidateQuery, CandidateModifyModel>
    {
        private readonly ConnectionString _connectionString;

        public GetCandidateQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CandidateModifyModel> Handle(GetCandidateQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, Name, Birthday, CurrentPosition, Note from candidates Where Id = @Id";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var dbResult = await conn.QueryFirstOrDefaultAsync<CandidateModifyModel>(sql, new { request.Id });
                return dbResult;
            }
        }
    }
}
