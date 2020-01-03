using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;

namespace Extensions
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var configuration = new Configuration();
            configuration.Configure("Properties/hibernate.cfg.xml");

            var sessionFactory = configuration.BuildSessionFactory();
    
            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
    
            return services;
        }
    }
}
