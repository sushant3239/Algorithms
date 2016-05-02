using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfflineSync.Core.Infrastructure
{
    public interface ISqliteConnetion
    {
        T Save<T>(T data) where T : class;
        Task<IEnumerable<T>> Get<T>() where T : class;
        Task<IEnumerable<T>> SaveAll<T>(IEnumerable<T> items) where T : class;
    }
}
