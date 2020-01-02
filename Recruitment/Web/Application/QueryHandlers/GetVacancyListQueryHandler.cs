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
    public class GetVacancyListQueryHandler : IRequestHandler<GetVacancyListQuery, List<VacancyListModel>>
    {
        private readonly ConnectionString _connectionString;
        public GetVacancyListQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<VacancyListModel>> Handle(GetVacancyListQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"select Id, Title, Description, OpenDate, CloseDate, ClientId from Vacancies where ClientId = @ClientId";

            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var dbResult = await connection.QueryAsync<VacancyListModel>(sql, new { request.ClientId });
                return dbResult.ToList();
            }
        }
    }
}
