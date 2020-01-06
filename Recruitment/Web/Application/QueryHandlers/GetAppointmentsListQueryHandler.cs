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
    public sealed class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentListModel>>
    {
        private readonly ConnectionString _connectionString;

        public GetAppointmentsListQueryHandler(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<AppointmentListModel>> Handle(GetAppointmentsListQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select A.Id, A.AppointmentType, A.StartsAt, C.CandidateName_FirstName + ' ' + C.CandidateName_LastName as CandidateName, V.Title as VacancyTitle
                        from Appointments as A
                        join Candidates as C on A.CandidateId = C.Id
                        join Vacancies as V on A.VacancyId = V.Id
                        order by A.StartsAt desc";

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var dbResult = await conn.QueryAsync<AppointmentListModel>(sql);
                return dbResult.ToList();
            }

        }
    }
}
