using NHibernate;
using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace ShowPlanner.DAL.NHibernate
{
    public class ArtistService : IArtistService
    {
        public void Delete(Artist obj)
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

        public IEnumerable<Artist> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Artist>().ToList();
            }
        }

        public Artist GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Query<Artist>().Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void Update(Artist obj)
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
