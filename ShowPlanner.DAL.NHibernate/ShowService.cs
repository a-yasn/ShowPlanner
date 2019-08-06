using NHibernate;
using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace ShowPlanner.DAL.NHibernate
{
    public class ShowService : IShowService
    {
        public void Delete(Show obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(obj);

                    transaction.Commit();
                }
            }
        }

        public IEnumerable<Show> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Show>().ToList();
            }
        }

        public Show GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Show>().Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void Update(Show obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(obj);

                    transaction.Commit();
                }
            }
        }
    }
}
