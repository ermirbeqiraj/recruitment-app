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
    public sealed class GetRequirementQueryHandler : IRequestHandler<GetRequirementQuery, RequirementUpdateModel>
    {
        private readonly ConnectionString _connectionString;

        public GetRequirementQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<RequirementUpdateModel> Handle(GetRequirementQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, SkillType, RequirementType, Content, VacancyId from Requirements where Id = @Id";

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var dbResult = await conn.QueryFirstOrDefaultAsync<RequirementUpdateModel>(sql, new { request.Id });
                return dbResult;
            }
        }
    }
}
