using System.Linq;
using System.Threading.Tasks;
using AsyncAspNetRequestTxInterceptor.Entities;

namespace Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Person entity);
        Task Delete(Person entity);
    }
}
