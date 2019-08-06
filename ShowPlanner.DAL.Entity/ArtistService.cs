using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace ShowPlanner.DAL.Entity
{
    public class ArtistService : IArtistService
    {
        public void Delete(Artist obj)
        {
            using (var context = new ShowPlannerDbContext())
            {
                context.Artists.Remove(obj);
                context.SaveChanges();
            }
        }

        public IEnumerable<Artist> GetAll()
        {
            using (var context = new ShowPlannerDbContext())
            {
                return context.Artists.ToList();
            }
        }

        public Artist GetById(int id)
        {
            using (var context = new ShowPlannerDbContext())
            {
                return context.Artists.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void Update(Artist obj)
        {
            using (var context = new ShowPlannerDbContext())
            {
                if (obj.Id == 0)
                {
                    context.Artists.Add(obj);
                }
                else
                {
                    context.Artists.Update(obj);
                }

                context.SaveChanges();
            }
        }
    }
}
