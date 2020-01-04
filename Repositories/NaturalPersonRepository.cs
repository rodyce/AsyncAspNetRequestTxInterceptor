using AsyncAspNetRequestTxInterceptor.Entities;
using NHibernate;

namespace Repositories
{
    public class NaturalPersonRepository : RepositoryBase<NaturalPerson>
    {
        public NaturalPersonRepository(ISession session) : base(session)
        {
        }
    }
}
