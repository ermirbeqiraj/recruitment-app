using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Application.Queries
{
    public class GetAppointmentQuery : IRequest<UpdateAppointmentModel>
    {
        public GetAppointmentQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
