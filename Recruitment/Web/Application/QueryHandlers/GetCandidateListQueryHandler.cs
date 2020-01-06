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
    public class GetCandidateListQueryHandler : IRequestHandler<GetCandidateListQuery, List<CandidateListModel>>
    {
        private readonly ConnectionString _connectionString;

        public GetCandidateListQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CandidateListModel>> Handle(GetCandidateListQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, (CandidateName_FirstName + ' ' + CandidateName_LastName) as [Name], Birthday, CurrentPosition, Note from candidates";

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var dbData = await conn.QueryAsync<CandidateListModel>(sql);
                return dbData.ToList();
            }
        }
    }
}
