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
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, UpdateAppointmentModel>
    {
        private readonly ConnectionString _connectionString;

        public GetAppointmentQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UpdateAppointmentModel> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Id, AppointmentType, StartsAt, CandidateId, VacancyId from Appointments where Id = @Id";

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var dbResult = await conn.QueryFirstOrDefaultAsync<UpdateAppointmentModel>(sql, new { request.Id });
                return dbResult;
            }
        }
    }
}
