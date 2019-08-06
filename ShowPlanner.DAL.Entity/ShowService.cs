using ShowPlanner.Domain;
using ShowPlanner.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace ShowPlanner.DAL.Entity
{
    public class ShowService : IShowService
    {
        public void Delete(Show obj)
        {
            using (var context = new ShowPlannerDbContext())
            {
                context.Shows.Remove(obj);
                context.SaveChanges();
            }
        }

        public IEnumerable<Show> GetAll()
        {
            using (var context = new ShowPlannerDbContext())
            {
                return context.Shows.ToList();
            }
        }

        public Show GetById(int id)
        {
            using (var context = new ShowPlannerDbContext())
            {
                return context.Shows.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void Update(Show obj)
        {
            using (var context = new ShowPlannerDbContext())
            {
                if (obj.Id == 0)
                {
                    context.Shows.Add(obj);
                }
                else
                {
                    context.Shows.Update(obj);
                }

                context.SaveChanges();
            }
        }
    }
}
