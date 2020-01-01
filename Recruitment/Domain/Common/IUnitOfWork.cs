using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
