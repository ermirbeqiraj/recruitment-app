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
    public class GetVacancyQueryHandler : IRequestHandler<GetVacancyQuery, VacancyUpdateModel>
    {
        private readonly ConnectionString _connectionString;
        public GetVacancyQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<VacancyUpdateModel> Handle(GetVacancyQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"select Id, Title, Description, OpenDate, CloseDate from Vacancies where Id = @Id";

            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var dbResult = await connection.QueryFirstOrDefaultAsync<VacancyUpdateModel>(sql, new { request.Id });
                return dbResult;
            }
        }
    }
}
