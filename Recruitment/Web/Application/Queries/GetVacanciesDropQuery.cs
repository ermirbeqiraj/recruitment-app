using MediatR;
using System.Collections.Generic;
using Web.Models;

namespace Web.Application.Queries
{
    public class GetVacanciesDropQuery : IRequest<List<DropModel>> { }
}
