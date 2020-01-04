using System.Linq;
using System.Threading.Tasks;
using AsyncAspNetRequestTxInterceptor.Entities;
using NHibernate;

namespace Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
    
        public UnitOfWork(ISession session)
        {
            _session = session;
        }
        
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }
    
        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }
    
        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }
    
        public void CloseTransaction()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    
        public async Task Save(Person entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }
    
        public async Task Delete(Person entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
