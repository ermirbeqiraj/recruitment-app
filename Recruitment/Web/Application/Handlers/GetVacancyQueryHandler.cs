using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Application.Queries;
using Web.Models;
using Web.Utils;

namespace Web.Application.Handlers
{
    public class GetVacancyQueryHandler : IRequestHandler<GetVacancyQuery, VacancyUpdateModel>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetVacancyQueryHandler(QueriesConnectionString connectionString)
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
