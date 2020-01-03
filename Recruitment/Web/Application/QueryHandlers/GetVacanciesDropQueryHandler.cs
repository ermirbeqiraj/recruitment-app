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
    public class GetVacanciesDropQueryHandler : IRequestHandler<GetVacanciesDropQuery, List<DropModel>>
    {
        private readonly ConnectionString _connectionString;

        public GetVacanciesDropQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<DropModel>> Handle(GetVacanciesDropQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, Title as [Text] from Vacancies";
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var result = await conn.QueryAsync<DropModel>(sql);
                return result.ToList();
            }
        }
    }
}
