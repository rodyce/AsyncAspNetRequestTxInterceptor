using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected RepositoryBase(ISession session)
        {
            Session = session;
            EntityType = typeof(T);
        }

        public Type EntityType { get; }
        private ISession Session { get; }

        public async virtual Task<IEnumerable<T>> LoadEntityList()
        {
            var criteria = CreateCriteria();
            return await criteria.ListAsync<T>();
        }


        public async virtual Task<T> LoadEntityById(long value)
        {
            return await LoadEntityById("ID", value);
        }

        public async virtual Task<T> LoadEntityById(string idField, long value)
        {
            var criteria = CreateCriteria();
            criteria.Add(Restrictions.Eq(idField, value));
            return await criteria.UniqueResultAsync<T>();
        }

        #region criteria creation methods
        public virtual ICriteria CreateCriteria()
        {
            return CreateCriteriaWithAlias(null);
        }

        public virtual ICriteria CreateCriteriaWithAlias(string alias)
        {

            var criteria = alias != null ? Session.CreateCriteria<T>(alias) : Session.CreateCriteria<T>();
            criteria.SetResultTransformer(Transformers.DistinctRootEntity);

            return criteria;
        }
        #endregion
    }
}
