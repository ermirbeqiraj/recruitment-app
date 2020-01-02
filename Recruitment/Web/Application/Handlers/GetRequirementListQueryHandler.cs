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
    public sealed class GetRequirementListQueryHandler : IRequestHandler<GetRequirementListQuery, List<RequirementListModel>>
    {
        private readonly QueriesConnectionString _connectionString;

        public GetRequirementListQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<RequirementListModel>> Handle(GetRequirementListQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, SkillType, RequirementType, Content, VacancyId from Requirements where VacancyId = @VacancyId";

            using (var connection = new SqlConnection(_connectionString.Value))
            {
                var dbData = await connection.QueryAsync<RequirementListModel>(sql, new { request.VacancyId });
                return dbData.ToList();
            }
        }
    }
}
